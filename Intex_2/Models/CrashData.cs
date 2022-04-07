using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Intex_2.Models
{
    public class CrashData
    {
        public float milepoint { get; set; }
        public float intersection { get; set; }
        public float teenager { get; set; }
        public float dark { get; set; }
        public float sing_veh { get; set; }
        public float city { get; set; }
        public float county { get; set; }
        public float route { get; set;  }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                milepoint, intersection, teenager, dark, sing_veh, city, county, route
            };
            int[] dimensions = new int[] { 1, 8 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
