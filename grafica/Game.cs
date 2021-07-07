using System;
using grafica.objetos;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace grafica
{
    
    public class Game : GameWindow
    {   
        public float trasladarBaseX = 0,trasladarBaseY = 0,trasladarBaseZ = 0;
        public double anguloBase = 1;
        public float escalarBase = 1f;
        public bool asd = false;
        Figura select;
        Escenario es1;

        public Game(int width,
                    int heigth,
                    string title) : base(width,heigth,GraphicsMode.Default,title){
            es1 = new Escenario(100,100,200);
            es1.add("silla",new Silla(15,30,15,new Vector3(30,30, -50)));
            es1.add("mesa" , new Mesa(30,20,30,new Vector3(30,20,-100)));
            select=es1;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.3f,0.2f,0.3f,1.0f);
            base.OnLoad(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            drawPoint(0,0,-1);
            es1.paint();
            dibujarplano();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            KeyboardState state = OpenTK.Input.Keyboard.GetState();
            switch (e.KeyChar)
            {   
                case ('W' or 'w'):
                    trasladarBaseY+=1;
                    select.trasladar(trasladarBaseX,trasladarBaseY,trasladarBaseZ);
                    Console.WriteLine(e.KeyChar);
                break;
                case ('s' or 'S'):
                    trasladarBaseY-=1;
                    select.trasladar(trasladarBaseX,trasladarBaseY,trasladarBaseZ);
                    Console.WriteLine(e.KeyChar);
                break;
                case ('A' or 'a'):
                    trasladarBaseX -=1;
                    select.trasladar(trasladarBaseX,trasladarBaseY,trasladarBaseZ);
                    Console.WriteLine(e.KeyChar);
                break;
                case ('D' or 'd'):
                    trasladarBaseX+=1;
                    select.trasladar(trasladarBaseX,trasladarBaseY,trasladarBaseZ);
                    Console.WriteLine(e.KeyChar);
                break;
                case ('Z' or 'z'):
                    trasladarBaseZ-=1;
                    select.trasladar(trasladarBaseX,trasladarBaseY,trasladarBaseZ);
                    Console.WriteLine(e.KeyChar);
                break;
                case ('X' or 'x'):
                    trasladarBaseZ+=1;
                    select.trasladar(trasladarBaseX,trasladarBaseY,trasladarBaseZ);
                    Console.WriteLine(e.KeyChar);
                break;
                case ('r' or 'R'):
                    select.rotar((float)anguloBase,1,0,0);
                    Console.WriteLine(e.KeyChar);
                    anguloBase++;
                break;
                case ('e' or 'E'):
                    escalarBase += (float)1;
                    select.escalar(escalarBase);
                    Console.WriteLine(e.KeyChar);
                    
                break;
                case ('q' or 'Q'):
                    escalarBase -= (float)1;
                    select.escalar(escalarBase);
                    Console.WriteLine(e.KeyChar);
                    
                break;
                case ('c' or 'C'):
                    Console.WriteLine(e.KeyChar);
                    Console.WriteLine(asd);
                    asd=!asd;
                    if(asd){
                        select = es1.get("mesa");
                    }else{
                        select = es1.get("silla");
                    }
                break;
                default:return;
            }
            base.OnKeyPress(e);
        }

        private void dibujarplano(){
            GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(-300,0,+1);
                GL.Vertex3(+300,0,+1);
            GL.End();
            GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(0,-300,+1);
                GL.Vertex3(0,+300,+1);
            GL.End();
        }

        private void drawPoint(double x, double y , double z){
            GL.PointSize(7);
            GL.Begin(PrimitiveType.Points);
             GL.Vertex3(x,y,z);
            GL.End();
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0,0,Width,Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f),(float)(Width/Height),0.1f,500.0f);
            GL.LoadMatrix(ref matrix);
            //GL.Ortho(-100,100,-100,100,-300.0,500.0f);
            GL.MatrixMode(MatrixMode.Modelview);
            base.OnResize(e);
            
        }
    }
}