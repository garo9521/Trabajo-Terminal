using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SAARTAC {
    internal class Reconstruccion {
        GameWindow window;
        double theta = 0.0;

        public Reconstruccion(GameWindow window) {
            this.window = window;
            Start();
        }

        void Start() {
            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60.0);
        }

        void loaded(object o, EventArgs e) {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

        }

        void renderF(object o, EventArgs e) {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Translate(0.0, 0.0, -512.0);
            GL.Rotate(theta, 1.0, 0.0, 0.0);
            GL.Rotate(theta, 1.0, 0.0, 1.0);



            GL.Begin(BeginMode.Quads);


            for (int j = 256; j > -256; j--) {
                for (int i = -256; i < 256; i++) {
                    //front
                    GL.Color3(1, 0.0, 0.0);
                    GL.Vertex3(i, j - 1, 10.0); //Abajo izquierda
                    GL.Vertex3(i + 1, j - 1, 10.0); //Abajo derecha
                    GL.Vertex3(i + 1.0, j, 10.0); //Arriba derecha
                    GL.Vertex3(i, j, 10.0); //Arriba izquierda

                    //back
                    GL.Color3(1, 0.0, 0.0);
                    GL.Vertex3(i, j - 1, 0.0); //Abajo izquierda
                    GL.Vertex3(i + 1, j - 1, 0.0); //Abajo derecha
                    GL.Vertex3(i + 1, j, 0.0); //Arriba derecha
                    GL.Vertex3(i, j, 0.0); //Arriba izquierda

                    //top
                    GL.Color3(1, 0.0, 0.0);
                    GL.Vertex3(i, j, 10.0); //Arriba izquierda front
                    GL.Vertex3(i + 1, j, 10.0); //Arriba derecha front
                    GL.Vertex3(i + 1, j, 0.0); //Arriba derecha back 
                    GL.Vertex3(i, j, 0.0); //Arriba izquierda back


                    //bottom
                    GL.Color3(1, 0.0, 0.0);
                    GL.Vertex3(i + 1, j - 1, 10.0); //Abajo derecha front
                    GL.Vertex3(i + 1, j - 1, 0.0); //Abajo derecha back
                    GL.Vertex3(i, j - 1, 0.0); //Abajo izquierda back
                    GL.Vertex3(i, j - 1, 10.0); //Abajo izquierda front

                    //rigth
                    GL.Color3(1, 0.0, 0.0);
                    GL.Vertex3(i + 1, j - 1, 10.0); //Abajo derecha front
                    GL.Vertex3(i + 1, j - 1, 0.0); //Abajo derecha back
                    GL.Vertex3(i + 1, j, 0.0); //Arriba derecha back
                    GL.Vertex3(i + 1, j, 10.0); //Arriba derecha front

                    //left
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex3(i, j - 1, 10.0); //Abajo izquierda front
                    GL.Vertex3(i, j - 1, 0.0); //Abajo izquierda back
                    GL.Vertex3(i, j, 0.0); //Arriba izquierda back
                    GL.Vertex3(i, j, 10.0); //Arriba izquierda front
                    
                   

                }

            }


            GL.End();

            window.SwapBuffers();

            theta += 60.0;

            if (theta > 360.0)
                theta = 0.0;

        }

        void resize(object o, EventArgs e) {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 matrix = Matrix4.Perspective(45.0f, window.Width / window.Height, 1.0f, 550.0f);
            GL.LoadMatrix(ref matrix);
            //GL.Ortho(0.0, 600.0, 600.0, 0.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}
