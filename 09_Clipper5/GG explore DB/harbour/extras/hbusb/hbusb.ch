/*
 * $Id: hbusb.ch 18723 2012-12-03 23:59:43Z vszakats $
 */

#ifndef HBUSB_CH
#define HBUSB_CH

#define LIBUSB_UNREF_DEVICES        1

#define LIBUSB_KERNEL_HAS_INTERFACE 1

#define LIBUSB_ENDPOINT_IN          129 /* Should be 128 and then && 1 when required */
#define LIBUSB_ENDPOINT_OUT         0

#endif
