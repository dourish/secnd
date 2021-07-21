# secnd
FORTH implementation for 65C02
Paul Dourish, December 2017

When I was 17, I wrote an implementation of FORTH in 6502 assembly
language in a notebook during my summer vacation, and later got
it working for my BBC Micro. The computer, the floppy disks, and the
notebook are, sadly, long gone. But lately I built a 65C02-based
single-board computer as a hobby and so, naturally, I need to have a
FORTH system for it too.

The old one was somewhat arbitrary, keeping to the rough parameters
of the one book I'd read on FORTH but not following any particular
conventions about implementation. (I do still have the book, at least.)
This newer FORTH hews closer to the standard models for the
interfunctioning of interpreter and compiler, the operation of
IMMEDIATE words, and so on. Where in doubt, it follows ANS Forth
although I'm being far from religious about it.

Chuck Moore's FORTH was an abbreviation of "fourth", limited by
the conventions of the filesystem on which it was written. This being
my second Forth implementation, "SECND" is an abbreviation of
"second" as an homage.

v01 is a very first, minimal implementation with a text interpreter
and just a few words.

v02 has a more fleshed out vocabulary, variables, and R-stack
manipulations.

v03 includes the initial compiler, plus strings, looping, and
conditionals.

v05 has recursion, double-length arithmetic, and signed arithmetic.

v06 is mainly focused on clean-up, efficiencies, bug fixes, and
migrating internal operations towards usual Forth models.

v07 added support for SD cards and the FAT16 filesystem, plus the block
system and screen editor.

v08 finally implemented create/does>, cleaned up lots of rough edges,
improved performance, and worked on both the compiler and interpreter
mechanisms to bring them more into line with standard FORTH practice.

v09 was the working version, for a good two years. It had some more
work on arithmetic routines, tightened the code to save space, expanded
the FAT16 code, and was turned to run in ROM as well as RAM. It
also added a jump table so that I can call ROM routines easily from
other programs.

v10 includes support for the new video output and keyoard input that
have been built into the computer, rather than operating through
the serial port.

Finally, I'm really just using github as a convenient repository
and backup. The code may work for others but I've not done any of
the work of cleaning and clarifying that would be involved in
making it available for others to use. As you can see from these
various versions, my development strategy is not particularly tuned
to git's facilities.

SECND was developed using the xa cross-assembler, so that's the
syntax being used here.

More information at https://www.dourish.com/projects/secnd.html.

