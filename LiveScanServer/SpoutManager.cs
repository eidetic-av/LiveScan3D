using System.Collections.Generic;
using System;
using OpenGL;
using Spout.Interop;
using System.Reflection;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KinectServer
{
    internal class SpoutManager
    {
        public static SpoutManager Instance;

        public uint streamWidth = 648;
        public uint streamHeight = 480;

        DeviceContext deviceContext;
        IntPtr glContext = IntPtr.Zero;
        SpoutSender colorSender;
        SpoutSender vertexSender;

        byte[] vertexBuffer;
        byte[] colorBuffer;

        public SpoutManager() => Instance = this;

        ~SpoutManager() => DisposeContext();

        public static void DisposeContext()
        {
            if (Instance.deviceContext == null) return;
            Instance.colorSender.Dispose();
            Instance.vertexSender.Dispose();
            Instance.deviceContext.Dispose();
            Instance.deviceContext = null;
        }

        public unsafe void SendFrame(List<float> vertices, List<byte> colors)
        {
            if (deviceContext == null)
            {
                deviceContext = DeviceContext.Create();
                glContext = deviceContext.CreateContext(IntPtr.Zero);
                deviceContext.MakeCurrent(glContext);
                vertexSender = new SpoutSender();
                vertexSender.CreateSender("LiveScanVertices", streamWidth, streamHeight, 0);
                colorSender = new SpoutSender();
                colorSender.CreateSender("LiveScanColors", (streamWidth / 3), streamHeight, 0);
                vertexBuffer = new byte[streamWidth * streamHeight * 4];
                colorBuffer = new byte[streamWidth * streamHeight];
            }

            lock (deviceContext)
            {
                var vertexValueCount = vertices.Count;
                if (vertexValueCount == 0) return;

                var colorsCount = colors.Count;
                var pixelCount = (int)(streamWidth * streamHeight);
                var nproc = TransferServer.spoutTransferThreads;

                Parallel.For(0, nproc, workerId =>
                {
                    var max = pixelCount * (workerId + 1) / nproc;
                    for (int i = pixelCount * workerId / nproc; i < max; i++)
                    {
                        // transfer vertices to buffer
                        // each individual float is passed into a 32-bit color
                        byte[] vertexData;
                        if (i < vertexValueCount)
                            vertexData = BitConverter.GetBytes(vertices[i]);
                        else vertexData = new byte[] { 0, 0, 0, 0 };
                        vertexData.CopyTo(vertexBuffer, i * 4);

                        // transfer colors to buffer
                        if (i < colorsCount)
                            colorBuffer[i] = colors[i];
                        else colorBuffer[i] = Byte.MinValue;
                    }
                });

                // transfer the buffers to spout
                fixed (byte* vertexDataPtr = vertexBuffer)
                {
                    vertexSender.SendImage(
                        vertexDataPtr,
                        streamWidth,
                        streamHeight,
                        Gl.RGBA,
                        false, //B invert
                        0 // Host FBO
                        );
                }
                fixed (byte* colorDataPtr = colorBuffer)
                {
                    colorSender.SendImage(
                        colorDataPtr,
                        (streamWidth / 3),
                        streamHeight,
                        Gl.RGB,
                        false, // B Invert
                        0 // Host FBO
                        );
                }
            }
        }
    }
}