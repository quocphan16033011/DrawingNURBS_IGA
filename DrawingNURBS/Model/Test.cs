
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Kitware.VTK;
using DEMSoft.Drawing;
using Orientation = DEMSoft.Drawing.Orientation;

namespace DrawingNURBS
{

    public class ViewerForm : Form
    {
        private SerialPort port;

        protected vtkRenderer ren1;

        private vtkOrientationMarkerWidget widget;

        public vtkRenderWindowInteractor renderWindowInteractor;

        private bool isPaper;

        private bool isCapturePicture;

        private double[] viewUpDirection;

        private double[] positionCamera;

        private double[] focalPoint;

        private ColormapBar colormap;

        private vtkScalarBarActor actorColormapBar;

        private int c = 0;

        private vtkActor actor;

        private List<vtkActor> listActorUpdate;

        private IContainer components = null;

        private ToolStrip toolStrip1;

        private ToolStripButton screenshot;

        private ToolStripButton Fit;

        private ToolStripButton iso;

        private ToolStripButton front;

        private ToolStripButton back;

        private ToolStripButton left;

        private ToolStripButton right;

        private ToolStripButton top;

        private ToolStripButton bottom;

        public RenderWindowControl viewerRender;

        private ToolStripSeparator toolStripSeparator1;

        private TrackBar trackBar1;

        private ToolStripButton toolStripButton1;

        private ToolStripComboBox toolStripComboBox1;

        private TextBox textBox1;

        private SerialPort serialPort1;

        public ViewerForm(bool isPaper = false, bool isCapturePicture = false)
        {
            viewUpDirection = new double[3] { 0.0, 1.0, 0.0 };
            positionCamera = new double[3] { 0.0, 0.0, 1.0 };
            focalPoint = new double[3];
            this.isPaper = isPaper;
            this.isCapturePicture = isCapturePicture;
            InitializeComponent();
            Show();
        }

        public void AddObject3D(Object3D o)
        {
            vtkActor p = o.GetActor();
            ren1.AddActor(p);
        }

        public void Clear()
        {
            ren1.RemoveAllViewProps();
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.Run(this);
        }

        private void Fit_Click(object sender, EventArgs e)
        {
            ren1.ResetCamera();
            ren1.GetRenderWindow().Render();
        }

        private void screenshot_Click(object sender, EventArgs e)
        {
            vtkWindowToImageFilter vtkWindowToImageFilter = vtkWindowToImageFilter.New();
            vtkRenderWindow renderWindow = viewerRender.RenderWindow;
            vtkWindowToImageFilter.SetInput(renderWindow);
            string text = "screenshot.jpeg";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Title = "Save screenshot";
            saveFileDialog.DefaultExt = "jpeg";
            saveFileDialog.Filter = "Picture (*.jpeg)|*.jpeg";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                text = saveFileDialog.FileName;
                vtkJPEGWriter vtkJPEGWriter = vtkJPEGWriter.New();
                vtkJPEGWriter.SetFileName(text);
                vtkJPEGWriter.SetInputConnection(vtkWindowToImageFilter.GetOutputPort());
                vtkJPEGWriter.Write();
            }
        }

        public void UpdateCamera()
        {
            vtkCamera vtkCamera = vtkCamera.New();
            vtkCamera.SetParallelProjection(1);
            vtkCamera.SetViewUp(viewUpDirection[0], viewUpDirection[1], viewUpDirection[2]);
            vtkCamera.SetPosition(positionCamera[0], positionCamera[1], positionCamera[2]);
            vtkCamera.SetFocalPoint(focalPoint[0], focalPoint[1], focalPoint[2]);
            ren1.SetActiveCamera(vtkCamera);
            ren1.ResetCamera();
            ren1.GetRenderWindow().Render();
        }

        private void front_Click(object sender, EventArgs e)
        {
            viewUpDirection = new double[3] { 0.0, 1.0, 0.0 };
            positionCamera = new double[3] { 0.0, 0.0, 1.0 };
            focalPoint = new double[3];
            UpdateCamera();
        }

        private void back_Click(object sender, EventArgs e)
        {
            viewUpDirection = new double[3] { 0.0, 1.0, 0.0 };
            positionCamera = new double[3] { 0.0, 0.0, -1.0 };
            focalPoint = new double[3];
            UpdateCamera();
        }

        private void left_Click(object sender, EventArgs e)
        {
            viewUpDirection = new double[3] { 0.0, 1.0, 0.0 };
            positionCamera = new double[3] { -1.0, 0.0, 0.0 };
            focalPoint = new double[3];
            UpdateCamera();
        }

        private void right_Click(object sender, EventArgs e)
        {
            viewUpDirection = new double[3] { 0.0, 1.0, 0.0 };
            positionCamera = new double[3] { 1.0, 0.0, 0.0 };
            focalPoint = new double[3];
            UpdateCamera();
        }

        private void top_Click(object sender, EventArgs e)
        {
            viewUpDirection = new double[3] { 0.0, 0.0, -1.0 };
            positionCamera = new double[3] { 0.0, 1.0, 0.0 };
            focalPoint = new double[3];
            UpdateCamera();
        }

        private void bottom_Click(object sender, EventArgs e)
        {
            viewUpDirection = new double[3] { 0.0, 0.0, 1.0 };
            positionCamera = new double[3] { 0.0, -1.0, 0.0 };
            focalPoint = new double[3];
            UpdateCamera();
        }

        private void iso_Click(object sender, EventArgs e)
        {
            IsoViewSetup isoViewSetup = new IsoViewSetup();
            if (isoViewSetup.ShowDialog() == DialogResult.OK)
            {
                vtkCamera vtkCamera = vtkCamera.New();
                vtkCamera.SetParallelProjection(1);
                vtkCamera.SetFocalPoint(0.0, 0.0, 0.0);
                switch (isoViewSetup.numPointView)
                {
                    case 0:
                        vtkCamera.SetPosition(-1.0, -1.0, -1.0);
                        break;
                    case 1:
                        vtkCamera.SetPosition(1.0, -1.0, -1.0);
                        break;
                    case 2:
                        vtkCamera.SetPosition(1.0, 1.0, -1.0);
                        break;
                    case 3:
                        vtkCamera.SetPosition(-1.0, 1.0, -1.0);
                        break;
                    case 4:
                        vtkCamera.SetPosition(-1.0, -1.0, 1.0);
                        break;
                    case 5:
                        vtkCamera.SetPosition(1.0, -1.0, 1.0);
                        break;
                    case 6:
                        vtkCamera.SetPosition(1.0, 1.0, 1.0);
                        break;
                    case 7:
                        vtkCamera.SetPosition(-1.0, 1.0, 1.0);
                        break;
                }

                switch (isoViewSetup.DirectionUpCheck)
                {
                    case 0:
                        vtkCamera.SetViewUp(1.0, 0.0, 0.0);
                        break;
                    case 1:
                        vtkCamera.SetViewUp(0.0, 1.0, 0.0);
                        break;
                    case 2:
                        vtkCamera.SetViewUp(0.0, 0.0, 1.0);
                        break;
                    case 3:
                        vtkCamera.SetViewUp(0.0, 1.0, 1.0);
                        break;
                    case 4:
                        vtkCamera.SetViewUp(1.0, 0.0, 1.0);
                        break;
                    case 5:
                        vtkCamera.SetViewUp(1.0, 1.0, 0.0);
                        break;
                }

                ren1.SetActiveCamera(vtkCamera);
                ren1.ResetCamera();
                ren1.GetRenderWindow().Render();
            }
        }

        public void SetColormapBarVisible(IObjectResult o, string nameResult, Orientation orient = Orientation.Horizontal)
        {
            ren1.RemoveActor(actorColormapBar);
            colormap = new ColormapBar(o.GetLookupTable(), nameResult, isPaper);
            colormap.SetOrientation(orient);
            actorColormapBar = colormap.GetVTKScalarBarActor();
            ren1.AddActor2D(actorColormapBar);
        }

        public void SetColormapBarVisible(ColorsRange o, string nameResult, Orientation orient = Orientation.Horizontal)
        {
            colormap = new ColormapBar(o.GetLookupTable(), nameResult, isPaper);
            colormap.SetOrientation(orient);
            ren1.AddActor2D(colormap.GetVTKScalarBarActor());
            ren1.ResetCamera();
        }

        public ColormapBar GetColormapBar()
        {
            return colormap;
        }

        public void AddText2D(Text2D text)
        {
            ren1.AddActor(text.GetVTKTextActor());
        }

        public int GetWidthViewer()
        {
            return ren1.GetSize()[0];
        }

        public int GetHeightViewer()
        {
            return ren1.GetSize()[1];
        }

        private void ViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isCapturePicture)
            {
                vtkRenderWindow renderWindow = viewerRender.RenderWindow;
                vtkWindowToImageFilter vtkWindowToImageFilter = vtkWindowToImageFilter.New();
                vtkWindowToImageFilter.SetInput(renderWindow);
                string text = "Picture";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }

                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;
                int millisecond = DateTime.Now.Millisecond;
                string fileName = text + "\\shot" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".jpeg";
                vtkJPEGWriter vtkJPEGWriter = vtkJPEGWriter.New();
                vtkJPEGWriter.SetFileName(fileName);
                vtkJPEGWriter.SetInputConnection(vtkWindowToImageFilter.GetOutputPort());
                vtkJPEGWriter.Write();
            }

            if (port != null && port.IsOpen)
            {
                port.Close();
            }

            GC.Collect();
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            vtkRenderWindow renderWindow = viewerRender.RenderWindow;
            ren1 = renderWindow.GetRenderers().GetFirstRenderer();
            vtkAxesActor vtkAxesActor = vtkAxesActor.New();
            vtkTransform vtkTransform = vtkTransform.New();
            vtkTransform.Scale(0.5, 0.5, 0.5);
            vtkAxesActor.SetUserTransform(vtkTransform);
            vtkAxesActor.PickableOn();
            if (isPaper)
            {
                int fontSize = 15;
                int num = 7;
                vtkAxesActor.GetXAxisCaptionActor2D().GetTextActor().SetTextScaleModeToNone();
                vtkAxesActor.GetXAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetFontSize(fontSize);
                vtkAxesActor.GetXAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetBold(0);
                vtkAxesActor.GetXAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetLineOffset(num);
                vtkAxesActor.GetXAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetColor(0.0, 0.0, 0.0);
                vtkAxesActor.GetYAxisCaptionActor2D().GetTextActor().SetTextScaleModeToNone();
                vtkAxesActor.GetYAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetFontSize(fontSize);
                vtkAxesActor.GetYAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetBold(0);
                vtkAxesActor.GetYAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetLineOffset(num);
                vtkAxesActor.GetYAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetColor(0.0, 0.0, 0.0);
                vtkAxesActor.GetZAxisCaptionActor2D().GetTextActor().SetTextScaleModeToNone();
                vtkAxesActor.GetZAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetFontSize(fontSize);
                vtkAxesActor.GetZAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetBold(0);
                vtkAxesActor.GetZAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetLineOffset(num);
                vtkAxesActor.GetZAxisCaptionActor2D().GetTextActor().GetTextProperty()
                    .SetColor(0.0, 0.0, 0.0);
            }

            ren1.GetActiveCamera().SetParallelProjection(1);
            ren1.GetActiveCamera().SetPosition(0.0, 0.0, 1000.0);
            ren1.GetActiveCamera().SetFocalPoint(0.0, 0.0, 0.0);
            if (isPaper)
            {
                ren1.SetBackground(1.0, 1.0, 1.0);
            }
            else
            {
                ren1.GradientBackgroundOn();
                Color gray = Color.Gray;
                Color black = Color.Black;
                ren1.SetBackground((double)(int)gray.R / 255.0, (double)(int)gray.G / 255.0, (double)(int)gray.B / 255.0);
                ren1.SetBackground2((double)(int)black.R / 255.0, (double)(int)black.G / 255.0, (double)(int)black.B / 255.0);
            }

            vtkLightCollection lights = ren1.GetLights();
            double intensity = 0.2;
            vtkLight vtkLight = vtkLight.New();
            vtkLight.SetPosition(1.0, 1.0, 1.0);
            vtkLight.SetLightTypeToCameraLight();
            vtkLight.SetDirectionAngle(10.0, 20.0);
            vtkLight.SetIntensity(0.7);
            ren1.AddLight(vtkLight);
            vtkLight vtkLight2 = vtkLight.New();
            vtkLight2.SetPosition(-1.0, -1.0, 1.0);
            vtkLight2.SetLightTypeToCameraLight();
            vtkLight2.SetIntensity(intensity);
            ren1.AddLight(vtkLight2);
            vtkLight vtkLight3 = vtkLight.New();
            vtkLight3.SetPosition(1.0, -1.0, 1.0);
            vtkLight3.SetLightTypeToCameraLight();
            vtkLight3.SetIntensity(intensity);
            ren1.AddLight(vtkLight3);
            vtkLight vtkLight4 = vtkLight.New();
            vtkLight4.SetPosition(-1.0, 1.0, 1.0);
            vtkLight4.SetLightTypeToCameraLight();
            vtkLight4.SetIntensity(intensity);
            ren1.AddLight(vtkLight4);
            renderWindowInteractor = vtkRenderWindowInteractor.New();
            renderWindowInteractor.SetRenderWindow(renderWindow);
            renderWindowInteractor.StartPickCallback();
            vtkInteractorStyleSwitch vtkInteractorStyleSwitch = vtkInteractorStyleSwitch.New();
            renderWindowInteractor.SetInteractorStyle(vtkInteractorStyleSwitch);
            vtkInteractorStyleSwitch.SetCurrentStyleToTrackballCamera();
            widget = vtkOrientationMarkerWidget.New();
            widget.SetOutlineColor(0.93, 0.57, 0.13);
            widget.SetOrientationMarker(vtkAxesActor);
            widget.SetInteractor(renderWindowInteractor);
            widget.SetViewport(0.0, 0.0, 0.3, 0.3);
            widget.SetEnabled(1);
            widget.InteractiveOff();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void DrawCursor()
        {
            vtkCursor3D vtkCursor3D = new vtkCursor3D();
            vtkCursor3D.SetModelBounds(-10.0, 10.0, -10.0, 10.0, -10.0, 10.0);
            vtkCursor3D.AllOn();
            vtkCursor3D.OutlineOff();
            vtkCursor3D.Update();
            vtkPolyDataMapper vtkPolyDataMapper = vtkPolyDataMapper.New();
            vtkPolyDataMapper.SetInputConnection(vtkCursor3D.GetOutputPort());
            vtkActor vtkActor = new vtkActor();
            vtkActor.GetProperty().SetColor(1.0, 0.0, 0.0);
            vtkActor.SetMapper(vtkPolyDataMapper);
            ren1.AddActor(vtkActor);
        }

        private void Test()
        {
            vtkCubeSource vtkCubeSource = new vtkCubeSource();
            vtkPolyDataMapper vtkPolyDataMapper = vtkPolyDataMapper.New();
            vtkPolyDataMapper.SetInput(vtkCubeSource.GetOutput());
            vtkActor vtkActor = new vtkActor();
            vtkActor.SetMapper(vtkPolyDataMapper);
            ren1.AddActor(vtkActor);
            vtkSphereSource vtkSphereSource = new vtkSphereSource();
            vtkSphereSource.SetCenter(0.0, 0.0, 0.0);
            vtkSphereSource.SetRadius(2.0);
            vtkSphereSource.SetPhiResolution(30);
            vtkSphereSource.SetThetaResolution(30);
            vtkPolyDataMapper vtkPolyDataMapper2 = vtkPolyDataMapper.New();
            vtkPolyDataMapper2.SetInputConnection(vtkSphereSource.GetOutputPort());
            actor = new vtkActor();
            actor.SetMapper(vtkPolyDataMapper2);
            actor.GetProperty().SetSpecular(0.6);
            actor.GetProperty().SetSpecularPower(30.0);
            actor.GetProperty().SetColor(1.0, 0.0, 0.0);
            vtkRenderWindow renderWindow = viewerRender.RenderWindow;
            ren1 = renderWindow.GetRenderers().GetFirstRenderer();
            ren1.AddActor(actor);
            ren1.SetBackground(0.0, 1.0, 0.0);
            renderWindow.Render();
        }

        private void animation_Click(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        public void AddActorUpdate(vtkActor actor)
        {
            if (listActorUpdate == null)
            {
                listActorUpdate = new List<vtkActor>();
            }

            listActorUpdate.Add(actor);
        }

        public vtkActor GetActorUpdate(int index)
        {
            if (listActorUpdate == null)
            {
                return null;
            }

            return listActorUpdate[index];
        }

        public void RemoveActor(vtkActor actor)
        {
            ren1.RemoveActor(actor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEMSoft.Drawing.ViewerForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.screenshot = new System.Windows.Forms.ToolStripButton();
            this.Fit = new System.Windows.Forms.ToolStripButton();
            this.iso = new System.Windows.Forms.ToolStripButton();
            this.front = new System.Windows.Forms.ToolStripButton();
            this.back = new System.Windows.Forms.ToolStripButton();
            this.left = new System.Windows.Forms.ToolStripButton();
            this.right = new System.Windows.Forms.ToolStripButton();
            this.top = new System.Windows.Forms.ToolStripButton();
            this.bottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.viewerRender = new Kitware.VTK.RenderWindowControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.trackBar1).BeginInit();
            base.SuspendLayout();
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
            {
            this.screenshot, this.Fit, this.iso, this.front, this.back, this.left, this.right, this.top, this.bottom, this.toolStripSeparator1,
            this.toolStripButton1, this.toolStripComboBox1
            });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(592, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.screenshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.screenshot.Image = (System.Drawing.Image)resources.GetObject("screenshot.Image");
            this.screenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.screenshot.Name = "screenshot";
            this.screenshot.Size = new System.Drawing.Size(23, 22);
            this.screenshot.Text = "Screenshot";
            this.screenshot.Click += new System.EventHandler(screenshot_Click);
            this.Fit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Fit.Image = (System.Drawing.Image)resources.GetObject("Fit.Image");
            this.Fit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Fit.Name = "Fit";
            this.Fit.Size = new System.Drawing.Size(23, 22);
            this.Fit.Text = "Fit";
            this.Fit.Click += new System.EventHandler(Fit_Click);
            this.iso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.iso.Image = (System.Drawing.Image)resources.GetObject("iso.Image");
            this.iso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iso.Name = "iso";
            this.iso.Size = new System.Drawing.Size(23, 22);
            this.iso.Text = "Iso";
            this.iso.Click += new System.EventHandler(iso_Click);
            this.front.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.front.Image = (System.Drawing.Image)resources.GetObject("front.Image");
            this.front.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.front.Name = "front";
            this.front.Size = new System.Drawing.Size(23, 22);
            this.front.Text = "Front";
            this.front.Click += new System.EventHandler(front_Click);
            this.back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.back.Image = (System.Drawing.Image)resources.GetObject("back.Image");
            this.back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(23, 22);
            this.back.Text = "Back";
            this.back.Click += new System.EventHandler(back_Click);
            this.left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.left.Image = (System.Drawing.Image)resources.GetObject("left.Image");
            this.left.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(23, 22);
            this.left.Text = "Left";
            this.left.Click += new System.EventHandler(left_Click);
            this.right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.right.Image = (System.Drawing.Image)resources.GetObject("right.Image");
            this.right.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(23, 22);
            this.right.Text = "Right";
            this.right.Click += new System.EventHandler(right_Click);
            this.top.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.top.Image = (System.Drawing.Image)resources.GetObject("top.Image");
            this.top.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(23, 22);
            this.top.Text = "Top";
            this.top.Click += new System.EventHandler(top_Click);
            this.bottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bottom.Image = (System.Drawing.Image)resources.GetObject("bottom.Image");
            this.bottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(23, 22);
            this.bottom.Text = "Bottom";
            this.bottom.Click += new System.EventHandler(bottom_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.viewerRender.AddTestActors = false;
            this.viewerRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerRender.Location = new System.Drawing.Point(0, 25);
            this.viewerRender.Name = "viewerRender";
            this.viewerRender.Size = new System.Drawing.Size(592, 427);
            this.viewerRender.TabIndex = 3;
            this.viewerRender.TestText = null;
            this.trackBar1.Location = new System.Drawing.Point(372, 0);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Scroll += new System.EventHandler(trackBar1_Scroll);
            this.textBox1.Location = new System.Drawing.Point(458, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 5;
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(592, 452);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.trackBar1);
            base.Controls.Add(this.viewerRender);
            base.Controls.Add(this.toolStrip1);
            base.Name = "ViewerForm";
            this.Text = "DEMSoft - Viewer";
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ViewerForm_FormClosed);
            base.Load += new System.EventHandler(ViewerForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.trackBar1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}