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
using Microsoft.Win32;
using Point = DEMSoft.Drawing.Point;
using DEMSoft.Drawing;
using DEMSoft.Drawing.Geometry;

namespace DrawingNURBS
{
    public partial class DrawingNURBS : Form
    {
        private Form mainForm;
        public ViewerForm DrawingBodyViewer;
        private vtkRenderer renderer;
        private vtkRenderWindowInteractor interactor;
        private vtkCamera camera;
        private vtkPicker picker = new vtkPicker();

        private List<Point> listPoints;
        private List<Point> listPointsPolyLine;
        private List<Point> listPointLine;
        static double[] CoordinateWorld;

        public DrawingNURBS()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.DrawingBodyViewer = new ViewerForm(true);
        }

        private void openDrawing(ViewerForm form)
        {
            mainForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            panel1.Controls.Add(form);
            panel1.Tag = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.UpdateCamera();
            listPoints = new List<DEMSoft.Drawing.Point>();
            listPointsPolyLine = new List<DEMSoft.Drawing.Point>();
            listPointLine = new List<Point>();
        }

        private void drawingNURBS_Load(object sender, EventArgs e)
        {
            openDrawing(DrawingBodyViewer);
            interactor = DrawingBodyViewer.renderWindowInteractor;
            renderer = DrawingBodyViewer.viewerRender.RenderWindow.GetRenderers().GetFirstRenderer();
            camera = renderer.GetActiveCamera();
            interactor.MouseMoveEvt += mouseMoveHandler;
            DrawingBodyViewer.UpdateCamera();
        }

        private void mouseMoveHandler(object sender, vtkObjectEventArgs e)
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

        public static double[] takeCoordinate()
        {
            return CoordinateWorld;
        }

        private void createPoint(vtkObject sender, vtkObjectEventArgs e)
        {
            Point point = new Point(CoordinateWorld[0], CoordinateWorld[1], CoordinateWorld[2]);
            point.ColorObject = Color.Red;
            point.SetPointSize(5);
            listPoints.Add(point);
            for (int i = 0; i < listPoints.Count; i++)
            {
                DrawingBodyViewer.AddObject3D(listPoints[i]);
                DrawingBodyViewer.Show();
                DrawingBodyViewer.viewerRender.RenderWindow.Render();

            }
        }

        private void createLine(vtkObject sender, vtkObjectEventArgs e)
        {

            Point point = new Point(CoordinateWorld[0], CoordinateWorld[1], CoordinateWorld[2]);
            listPointLine.Add(point);
            if (listPointLine.Count == 2)
            {
                double[] x = new double[listPointLine.Count];
                double[] y = new double[listPointLine.Count];
                double[] z = new double[listPointLine.Count];

                for (int i = 0; i < listPointLine.Count; i++)
                {
                    x[i] = listPointLine[i].GetCoordinate()[0];
                    y[i] = listPointLine[i].GetCoordinate()[1];
                    z[i] = listPointLine[i].GetCoordinate()[2];
                    listPointLine[i].ColorObject = Color.Red;
                    listPointLine[i].SetPointSize(5);
                }
                Line line = new Line(x[0], y[0], z[0], x[1], y[1], z[1]);
                line.ColorObject = Color.Black;
                line.SetWidth(1);
                DrawingBodyViewer.AddObject3D(line);
                DrawingBodyViewer.AddObject3D(listPointLine[0]);
                DrawingBodyViewer.AddObject3D(listPointLine[1]);
                DrawingBodyViewer.viewerRender.RenderWindow.Render();
                listPointLine = new List<Point>();
            }

        }

        private void createPolyLine(vtkObject sender, vtkObjectEventArgs e)
        {
            DEMSoft.Drawing.Point point = new DEMSoft.Drawing.Point(CoordinateWorld[0], CoordinateWorld[1], CoordinateWorld[2]);
            point.ColorObject = Color.Red;
            point.SetPointSize(5);
            listPointsPolyLine.Add(point);
            //DrawingBodyViewer.Clear();
            for (int i = 0; i < listPointsPolyLine.Count; i++)
            {
                DrawingBodyViewer.AddObject3D(listPointsPolyLine[i]);
                DrawingBodyViewer.Show();
                //DrawingBodyViewer.UpdateCamera();
            }
            if (listPointsPolyLine.Count >= 2)
            {
                double[] x = new double[listPointsPolyLine.Count];
                double[] y = new double[listPointsPolyLine.Count];
                double[] z = new double[listPointsPolyLine.Count];

                for (int i = 0; i < listPointsPolyLine.Count; i++)
                {
                    x[i] = listPointsPolyLine[i].GetCoordinate()[0];
                    y[i] = listPointsPolyLine[i].GetCoordinate()[1];
                    z[i] = listPointsPolyLine[i].GetCoordinate()[2];
                }
                Polyline polyline = new Polyline(x, y, z);
                polyline.ColorObject = Color.Black;
                polyline.SetWidth(1);
                DrawingBodyViewer.AddObject3D(polyline);
                DrawingBodyViewer.viewerRender.RenderWindow.Render();
            }
        }

        private void PointBtn_Click(object sender, EventArgs e)
        {
            interactor.MiddleButtonPressEvt += createPoint;
            interactor.MiddleButtonPressEvt -= createPolyLine;
            interactor.MiddleButtonPressEvt -= createLine;
        }

        private void PolyLineBtn_Click(object sender, EventArgs e)
        {
            interactor.MiddleButtonPressEvt -= createPoint;
            interactor.MiddleButtonPressEvt -= createLine;
            interactor.MiddleButtonPressEvt += createPolyLine;
        }

        private void LineBtn_Click(object sender, EventArgs args)
        {
            interactor.MiddleButtonPressEvt -= createPoint;
            interactor.MiddleButtonPressEvt -= createPolyLine;
            interactor.MiddleButtonPressEvt += createLine;
        }

        private void CancelTool(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LineBtn.Enabled = false;
                LineBtn.IsAccessible = false;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            listPointLine.Clear();
            listPoints.Clear();
            listPointsPolyLine.Clear();
            DrawingBodyViewer.Clear();
            DrawingBodyViewer.viewerRender.RenderWindow.Render();
        }
    }
}
