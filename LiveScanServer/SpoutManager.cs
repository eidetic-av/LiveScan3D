using System.Collections.Generic;
using System;
using System.IO;
using System.Threading;
using OpenGL;
using Spout.Interop;

namespace KinectServer
{
    internal class SpoutManager
    {
        readonly (uint width, uint height) streamSize = (640, 480);

        IntPtr glContext = IntPtr.Zero;
        DeviceContext deviceContext;
        SpoutSender colorSender;
        SpoutSender vertexSender;

        public SpoutManager()
        {
        }

        ~SpoutManager()
        {
            deviceContext.Dispose();
            deviceContext = null;
        }

        public unsafe void SendFrame(List<float> vertices, List<byte> colors)
        {
            if (deviceContext == null)
            {
                deviceContext = DeviceContext.Create();
                glContext = deviceContext.CreateContext(IntPtr.Zero);
                deviceContext.MakeCurrent(glContext); // Make this the primary context
                colorSender = new SpoutSender();
                colorSender.CreateSender("Colors", streamSize.width, streamSize.height, 0); // Create the sender
                vertexSender = new SpoutSender();
                vertexSender.CreateSender("Vertices", streamSize.width, streamSize.height, 0); // Create the sender
            }
            int colorCount = colors.Count;

            byte[] colorData = new byte[streamSize.width * streamSize.height * 3];
            for (int i = 0; i < colorData.Length - 1; i++)
                colorData[i] = i < colorCount - 1 ? colors[i] : Byte.MinValue;

            fixed (byte* colorDataPtr = colorData) // Get the pointer of the byte array
            {
                colorSender.SendImage(
                    colorDataPtr,
                    streamSize.width,
                    streamSize.height,
                    Gl.RGB,
                    true, // B Invert
                    0 // Host FBO
                    );
            }

            int vertexCount = vertices.Count;
            byte[] vertexData = new byte[streamSize.width * streamSize.height * 3 * sizeof(ushort)];

            int byteNum = 0;
            for (int i = 0; i < vertexCount - 1; i+=3)
            {
                var x = vertices[i];
                var y = vertices[i + 1];
                var z = vertices[i + 2];
                // assume min, max values of -10, 10 (metres in space)
                // convert to mix, max of 0, 1
                var normalisedX = ((x / 10f) + 1) / 2f;
                var normalisedY = ((y / 10f) + 1) / 2f;
                var normalisedZ = ((z / 10f) + 1) / 2f;
                // convert (and crop) it to a short
                var shortX = Convert.ToUInt16(normalisedX * ushort.MaxValue);
                var shortY = Convert.ToUInt16(normalisedY * ushort.MaxValue);
                var shortZ = Convert.ToUInt16(normalisedZ * ushort.MaxValue);
                // get the bytes of each
                var dataX = BitConverter.GetBytes(shortX);
                var dataY = BitConverter.GetBytes(shortY);
                var dataZ = BitConverter.GetBytes(shortZ);
                // pack vertices into shorts split in two.
                // where (pixel_n % 2 == 0) contains X,Y,Z coarse bits
                // and (pixel_n % 2 == 1) contains X,Y,Z fine bits
                vertexData[byteNum] = dataX[0];
                vertexData[byteNum + 1] = dataY[0];
                vertexData[byteNum + 2] = dataZ[0];
                vertexData[byteNum + 3] = dataX[1];
                vertexData[byteNum + 4] = dataY[1];
                vertexData[byteNum + 5] = dataZ[1];
                byteNum += 6;

            }

            fixed (byte* vertexDataPtr = vertexData)
            {
                vertexSender.SendImage(
                    vertexDataPtr,
                    streamSize.width,
                    streamSize.height,
                    Gl.RGB,
                    true, //B invert
                    0 // Host FBO
                    );
            }
        }
    }
}