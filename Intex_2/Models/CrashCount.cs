using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models
{
    public class CrashCount
    {
        public float crash_month { get; set; }
        public float crash_weekday { get; set; }
        public float county_name { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
               crash_month, crash_weekday, county_name
            };
            int[] dimensions = new int[] { 1, 3 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
