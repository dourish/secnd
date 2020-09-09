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
of the book I'd read on FORTH but not following any particular
conventions about implementation. This one hews closer to the
standard models for the interfunctioning of interpreter and compiler,
the operation of IMMEDIATE words, and so on. Where in doubt, it follows
ANS Forth although I'm being far from religious about it.

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

v09 is the current version, which has involved some more work on
arithmetic routines, tightening the code to save space, expanding the
FAT16 code, and shaping up a version that I can happily embed in a ROM.
It also adds a jump table so that I can call ROM routines easily from
other programs.

Finally, I'm really just using github as a convenient repository
and backup. The code may work for others but I've not done any of
the work of cleaning and clarifying that would be involved in
making it available for others to use.

SECND was developed using the xa cross-assembler, so that's the
syntax being used here.

More information at https://www.dourish.com/projects/secnd.html.

