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
the operation of IMMEDIATE words, and so on.

FORTH was an abbreviation of "fourth", limited by the conventions
of the filesystem on which it was written. "SECND" is an abbreviation
of "second" as an homage.

v01 is a very first, minimal implementation with a text interpreter
and just a few words.

v02 has a more fleshed out vocabulary, variables, and R-stack
manipulations.

v03 will include the initial compiler, plus strings, looping, and
conditionals.

Finally, I'm really just using github as a convenient repository
and backup. The code may work for others but I've not done any of
the work of cleaning and clarifying that would be involved in
making it available for others to use.
