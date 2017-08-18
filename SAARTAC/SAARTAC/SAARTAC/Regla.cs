using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAARTAC
{
    class Regla{
        private Point PuntoInicio, PuntoFin;        

        public Regla(int x, int y){
            PuntoInicio = new Point(x, y);
        }

        public void setFinal(int x, int y){
            PuntoFin = new Point(x, y);
        }

        public Point getPointInicio(){
            return PuntoInicio;
        }

        public Point getPoinFinal(){
            return PuntoFin;
        }
    }
}
