using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão
{
    public struct Disposição
    {
        private ulong cpu;
        private float ram;
        private float usoCpu;

        public Disposição(ulong cpu, float ram, float usoCpu)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.usoCpu = usoCpu;
        }

        public ulong CPU { get { return cpu; } }
        public float RAM { get { return ram; } }
        public float UsoCPU { get { return usoCpu; } }
    }
}
