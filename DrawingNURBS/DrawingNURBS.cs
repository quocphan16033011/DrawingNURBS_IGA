using SharpGL;
using SharpGL.Shaders;
using SharpGL.VertexBuffers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Reflection;
using Kitware.VTK;
//using DEMSoft.Drawing;
using Microsoft.Win32;
using DEMSoft.Drawing;
//using DrawingNURBS;

namespace DrawingNURBS
{
    public partial class DrawingNURBS : Form
    {
        private ViewerForm DrawingBodyViewer;
        private vtkRenderer renderer;
        private vtkRenderWindowInteractor interactor;
        private vtkCamera camera;
        private vtkPicker picker = new vtkPicker();
        private List<DEMSoft.Drawing.Point> listPoints;
        private List<DEMSoft.Drawing.Point> listPointsLine;
        private double[] CoordinateWorld;
        public DrawingNURBS()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.DrawingBodyViewer = new ViewerForm(true);
        }

        private Form mainForm;
        private void OpenDrawing(ViewerForm form)
        {
            mainForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            panel1.Controls.Add(form);
            panel1.Tag = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.SendToBack();
            DEMSoft.Drawing.Point point = new DEMSoft.Drawing.Point(10, 10, 0);
            point.SetPointSize(5);
            point.SetRandomColor();
            //form.AddObject3D(point);
            Origin origin = new Origin(new Coordination(TypeCoordination.Cartesian), 10);
            //form.AddObject3D(origin);
            form.UpdateCamera();
            listPoints = new List<DEMSoft.Drawing.Point>();
            listPointsLine = new List<DEMSoft.Drawing.Point>();
            //form.Show();
        }

        private void DrawingNURBS_Load(object sender, EventArgs e)
        {
            OpenDrawing(DrawingBodyViewer);
            interactor = DrawingBodyViewer.renderWindowInteractor;
            renderer = DrawingBodyViewer.viewerRender.RenderWindow.GetRenderers().GetFirstRenderer();
            camera = renderer.GetActiveCamera();
            interactor.MouseMoveEvt += MouseMoveHandler;
        }

        private void MouseMoveHandler(object sender, vtkObjectEventArgs e)
        {
            vtkRenderWindowInteractor interactor = (vtkRenderWindowInteractor)sender;

            //int[] mousePos = interactor.GetEventPosition();
            //picker.Pick(mousePos[0], mousePos[1], 0, renderer);
            //double[] worldPos = picker.GetPickPosition();

            int[] mousePos = interactor.GetEventPosition();

            double[] displayPos = new double[3];
            displayPos[0] = mousePos[0];
            displayPos[1] = mousePos[1];
            displayPos[2] = 0.0;

            renderer.SetDisplayPoint(displayPos[0], displayPos[1], displayPos[2]);
            renderer.DisplayToWorld();

            CoordinateWorld = renderer.GetWorldPoint();

            string coordinates = $"X: {Math.Round(CoordinateWorld[0], 2)}, Y: {Math.Round(CoordinateWorld[1], 2)}, Z: {Math.Round(CoordinateWorld[2], 2)}";
            Coordinate.Text = coordinates;
        }

        private void CreatePoint(vtkObject sender, vtkObjectEventArgs e)
        {
            DEMSoft.Drawing.Point point = new DEMSoft.Drawing.Point(CoordinateWorld[0], CoordinateWorld[1], CoordinateWorld[2]);
            point.ColorObject = Color.Red;
            point.SetPointSize(5);
            listPoints.Add(point);
            for (int i = 0; i < listPoints.Count; i++)
            {
                DrawingBodyViewer.AddObject3D(listPoints[i]);
                DrawingBodyViewer.Show();
                //DrawingBodyViewer.UpdateCamera();
            }
        }

        private void CreateLine(vtkObject sender, vtkObjectEventArgs e)
        {
            DEMSoft.Drawing.Point point = new DEMSoft.Drawing.Point(CoordinateWorld[0], CoordinateWorld[1], CoordinateWorld[2]);
            point.ColorObject = Color.Red;
            point.SetPointSize(5);
            listPointsLine.Add(point);
            //DrawingBodyViewer.Clear();
            for (int i = 0; i < listPointsLine.Count; i++)
            {
                DrawingBodyViewer.AddObject3D(listPointsLine[i]);
                DrawingBodyViewer.Show();
                //DrawingBodyViewer.UpdateCamera();
            }
            if (listPointsLine.Count >= 2)
            {
                double[] x = new double[listPointsLine.Count];
                double[] y = new double[listPointsLine.Count];
                double[] z = new double[listPointsLine.Count];

                for (int i = 0; i < listPointsLine.Count; i++)
                {
                    x[i] = listPointsLine[i].GetCoordinate()[0];
                    y[i] = listPointsLine[i].GetCoordinate()[1];
                    z[i] = listPointsLine[i].GetCoordinate()[2];
                }
                Polyline polyline = new Polyline(x, y, z);
                polyline.ColorObject = Color.Black;
                polyline.SetWidth(5);
                DrawingBodyViewer.AddObject3D(polyline);
            }

        }

        private void PointBtn_Click(object sender, EventArgs e)
        {
            interactor.MiddleButtonPressEvt += CreatePoint;
            interactor.MiddleButtonPressEvt -= CreateLine;
        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            interactor.MiddleButtonPressEvt += CreateLine;
            interactor.MiddleButtonPressEvt -= CreatePoint;
        }

        private void CancelTool(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LineBtn.Enabled = false;
                LineBtn.IsAccessible = false;
            }
        }
    }
}
