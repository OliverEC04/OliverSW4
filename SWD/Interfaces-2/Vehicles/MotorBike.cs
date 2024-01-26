using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class MotorBike

    {
        
        private IEngine _engine = null;

        public MotorBike(IEngine engine)

        {

            _engine = engine;

        }

        void RunAtHalfSpeed()

        {

            _engine.SetThrottle(_engine.MaxThrottle / 2);

        }

    }
}
