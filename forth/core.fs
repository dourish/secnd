32 constant bl

: space bl emit ;
: spaces 0 do space loop ;
: clear 74 50 91 27 emit emit emit emit ;
: home 72 91 27 emit emit emit ;
: page clear home ;

: numemit
  dup 10 < if
    48 + emit
  else
    10 /mod
      48 + emit 48 + emit
  then ;

: at-xy \ ESC [ line ; column H ;
  27 emit 91 emit swap numemit 59 emit numemit 72 emit ;

( ports and direction registers on the 6522 VIA )
32768 constant portb
32769 constant porta
32770 constant ddrb
32771 constant ddra

1024 constant b/buf
1024 constant b/scr

: >body 2+ ;
: buffer: create allot ;     \ is this one right?
: copy swap block swap buffer b/buf cmove update ;
: cell+ 2+ ;
: char+ 1+ ;
: chars ;
: align ;
: d>s swap drop ;
: 0< 0 < ;
: 0> 0 > ;




