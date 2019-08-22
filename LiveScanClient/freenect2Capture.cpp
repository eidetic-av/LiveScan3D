//   Copyright (C) 2015  Marek Kowalski (M.Kowalski@ire.pw.edu.pl), Jacek Naruniec (J.Naruniec@ire.pw.edu.pl)
//   License: MIT Software License   See LICENSE.txt for the full license.

//   If you use this software in your research, then please use the following citation:

//    Kowalski, M.; Naruniec, J.; Daniluk, M.: "LiveScan3D: A Fast and Inexpensive 3D Data
//    Acquisition System for Multiple Kinect v2 Sensors". in 3D Vision (3DV), 2015 International Conference on, Lyon, France, 2015

//    @INPROCEEDINGS{Kowalski15,
//        author={Kowalski, M. and Naruniec, J. and Daniluk, M.},
//        booktitle={3D Vision (3DV), 2015 International Conference on},
//        title={LiveScan3D: A Fast and Inexpensive 3D Data Acquisition System for Multiple Kinect v2 Sensors},
//        year={2015},
//    }

#include "Freenect2Capture.h"

#include <iostream>

#include <libfreenect2/libfreenect2.hpp>
#include <libfreenect2/packet_pipeline.h>
#include <libfreenect2/frame_listener_impl.h>
#include <libfreenect2/registration.h>

using namespace std;
using namespace libfreenect2;

Freenect2 freenect2;
Freenect2Device* dev = 0;
Registration* registration;
Frame undistorted(512, 424, 4), registered(512, 424, 4);

SyncMultiFrameListener listener(Frame::Color | Frame::Ir | Frame::Depth);

Freenect2Capture::Freenect2Capture()
{
}

Freenect2Capture::~Freenect2Capture()
{
	if (dev != 0)
	{
		dev->stop();
		dev->close();
		delete registration;
	}
}

bool Freenect2Capture::Initialize()
{
	//PacketPipeline* pipeline = new CudaPacketPipeline(-1);
	PacketPipeline* pipeline = new CpuPacketPipeline();

	string serial = freenect2.getDefaultDeviceSerialNumber();

	dev = freenect2.openDevice(serial, pipeline);

	if (dev == 0)
	{
		cout << "Failed to open Freenect2 device" << endl;
		return false;
	}
	else cout << "Opened Freenect2 device" << endl;

	dev->setColorFrameListener(&listener);
	dev->setIrAndDepthFrameListener(&listener);

	if (!dev->start())
	{
		cout << "Failed to start Freenect2 frame capture" << endl;
		bInitialized = false;
	}
	else {
		cout << "Started Freenect2 frame capture" << endl;
		bInitialized = true;
	}

	registration = new Registration(dev->getIrCameraParams(), dev->getColorCameraParams());

	// acquire an initial frame to make sure its all working?
	bool bTemp;
	do
	{
		bTemp = AcquireFrame();
	} while (!bTemp);

	return bInitialized;
}

bool Freenect2Capture::AcquireFrame()
{
	if (!bInitialized)
	{
		return false;
	}

	FrameMap frames;
	if (!listener.waitForNewFrame(frames, 10000))
	{
		cout << "Frame acquisition timed out..." << endl;
		return false;
	}

	Frame* rgb = frames[Frame::Color];
	Frame* ir = frames[Frame::Ir];
	Frame* depth = frames[Frame::Depth];

	registration->apply(rgb, depth, &undistorted, &registered);

	if (pDepth == NULL) pDepth = new UINT16[512 * 424];
	if (pColorRGBX == NULL) pColorRGBX = new RGB[rgb->width * rgb->height];

	memcpy(pColorRGBX, rgb->data, rgb->width * rgb->height * sizeof(RGB));
	memcpy(pDepth, depth->data, 512 * 424 * sizeof(UINT16));

	//cout << (int)pColorRGBX[0].rgbRed << endl;

	listener.release(frames);

	return true;
}

void Freenect2Capture::MapDepthFrameToCameraSpace(Point3f* pCameraSpacePoints)
{
}

void Freenect2Capture::MapColorFrameToCameraSpace(Point3f* pCameraSpacePoints)
{
}

void Freenect2Capture::MapDepthFrameToColorSpace(Point2f* pColorSpacePoints)
{
}

void Freenect2Capture::MapColorFrameToDepthSpace(Point2f* pDepthSpacePoints)
{
}