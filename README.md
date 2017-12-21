# secnd
FORTH implementation for 65C02

When I was 17, I wrote an implementation of FORTH for the 6502
microprocessor in a notebook during my summer vacation, and later got
it working for the BBC Micro. The computer, the floppy disks, and the
notebook are, sadly, long gone. But I lately built a 65C02-based
single-board computer as a hobby and so, naturally, I need to have a
FORTH system for it too.

The last one was somewhat arbitrary, keeping to the rough parameters
of the book I'd read on FORTH but not following any particular
conventions about implementation. This one is hewing closer to the
standard models for the interfunctioning of interpreter and compiler,
the operation of IMMEDIATE words, and so on.

v01 is a very first, minimal implementation with a text interpreter
and just a few words.

v02 has a more fleshed out vocabulary and will also have looping and
variables, but still no compiler.
