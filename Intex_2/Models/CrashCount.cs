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
            float[] data = new float[48];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }

            data[(int)crash_month] = 1;
            data[(int)crash_weekday] = 1;
            data[(int)county_name] = 1;

            int[] dimensions = new int[] { 1, 48 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
