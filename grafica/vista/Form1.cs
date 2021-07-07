using System;
using System.Windows.Forms;
using grafica.objetos;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections;
using KeyPressEventArgs = System.Windows.Forms.KeyPressEventArgs;
using grafica.controller;

namespace grafica
{
    public partial class Form1 : Form
    {
        Escenario escenario = new Escenario(100, 100, 200);
        private Timer _timer = null!;
        Figura select = null;
        float tx = 0, ty = 0, tz = 0,e=1,angleX=0,angleY=0,angleZ=0;
        private EventKeyController press = new EventKeyController();


        public Form1()
        {
            escenario.add("silla", new Silla(15, 30, 15, new Vector3(30, 30, -50)));
            escenario.add("mesa", new Mesa(30, 20, 30, new Vector3(30, 20, -100)));
            select = escenario;
            InitializeComponent();
            cargarObjetos();
            cargarPartes();
        }

        private void cargarObjetos()
        {
            menuObjeto.DropDownItems.Add("escenario",null,this.selectFigura);
            foreach (var objetos in select.partesObjeto)
            {
                menuObjeto.DropDownItems.Add(objetos.Key, null, this.selectFigura);
            }
        }

        private void cargarPartes()
        {
            if (select.partesObjeto != null)
            {
                menuPartes.DropDownItems.Clear();
                foreach (var objetos in select.partesObjeto)
                {
                    menuPartes.DropDownItems.Add(objetos.Key,null,this.selectFigura);
                }
            }
            
        }

        private void selectFigura(object sender, EventArgs e)
        {
            if (sender.ToString() == "escenario")
            {
                select = escenario;
            }
            else
            {
                select = select.partesObjeto[sender.ToString()];
                MessageBox.Show(sender.ToString());
            }
            cargarPartes();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.2f, 0.3f, 1.0f);
            glControl1.Resize += glControl1_Resize;
            glControl1.Paint += glControl1_Paint;

            _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                Render();
            };
            _timer.Interval = 50;
            _timer.Start();
            glControl1_Resize(glControl1, EventArgs.Empty);
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();
            GL.Viewport(0, 0, glControl1.ClientSize.Width, glControl1.ClientSize.Height);
            float aspect_ratio = Math.Max(glControl1.ClientSize.Width, 1) / (float)Math.Max(glControl1.ClientSize.Height, 1);
            GL.MatrixMode(MatrixMode.Projection);
            //Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90), aspect_ratio, 0.001f ,500f);
            //GL.LoadMatrix(ref matrix);
            GL.Ortho(-100,100,-100,100,-300.0,500.0f);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void glControl1_Paint(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            glControl1.MakeCurrent();
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            escenario.paint();
            glControl1.SwapBuffers();
        }

        private void glControl1_KeyPress(object sender, KeyPressEventArgs e)

        {
            char letra = e.KeyChar;
            if (verificarTecla(letra))
            {
                if (rotate.Checked)
                {
                    Rotate(letra);
                }
                if (traslate.Checked)
                {
                    Traslate(letra);
                }
                if (scale.Checked)
                {
                    Scale(letra);
                }
            }
            
        }


        private bool verificarTecla(char letra)
        {
            var vocal = new ArrayList(){
                'a','A','w','W','d','D','s','S','z','Z','x','X','E','e','Q','q',
            };
            return vocal.Contains(letra);
        }

        private void Rotate(char letra)
        {
            switch (letra)
            {
                case ('W' or 'w'):
                    angleX += 1;
                    select.rotar(angleX,1,0,0);
                break;
                case ('s' or 'S'):
                    angleX -= 1;
                    select.rotar(angleX, 1, 0, 0);
                    break;
                case ('A' or 'a'):
                    angleY-= 1;
                    select.rotar(angleY, 0, 1, 0);
                    break;
                case ('D' or 'd'):
                    angleY += 1;
                    select.rotar(angleY, 0,1,0);
                break;
                case ('Z' or 'z'):
                    angleZ += 1;
                    select.rotar(angleZ, 0, 0, 1);
                    break;
                case ('X' or 'x'):
                    angleZ -= 1;
                    select.rotar(angleZ, 0, 0, 1);
                    break;
                default:
                    break;
            }
        }

        private void Scale(char letra)
        {
            switch (letra)
            {
                case ('E' or 'e'):
                    e += (float)0.01;
                    break;
                case ('Q' or 'q'):
                    e -= (float)0.01;
                    break;
                default:
                    break;
            }
            select.escalar(e);
        }

        private void Traslate(char letra)
        {
            switch (letra)
            {
                case ('W' or 'w'):
                    ty += 1;
                    break;
                case ('s' or 'S'):
                    ty -= 1;
                    break;
                case ('A' or 'a'):
                    tx -= 1;
                    break;
                case ('D' or 'd'):
                    tx += 1;
                    break;
                case ('Z' or 'z'):
                    tz += 1;
                    break;
                case ('X' or 'x'):
                    tz -= 1;
                    break;
                default:
                    break;
            }
            select.trasladar(tx, ty, tz);
            tx = 0; ty = 0; tz = 0;
        }
    }
}
