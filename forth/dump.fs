
: hexchar s" 0123456789ABCDEF " drop + 1 type ;

: hexbyte dup 240 and 4 rshift hexchar 15 and hexchar ;

: charordot ( c -- )
  dup dup 32 < swap 127 = or if drop 46 emit else emit then ;

: charform ( u -- )
  dup 16 + swap do i c@ charordot loop ;

: hex16 (  u -- )
  dup 255 8 lshift and 8 rshift hexbyte 255 and hexbyte ;

: lefthex ( u -- )
  dup 8 + swap do i c@ hexbyte space loop ;

: righthex ( u -- )
  dup 16 + swap 8 + do i c@ hexbyte space loop ;

: hexform dup lefthex space righthex ;

: address ( u -- )
  hex16 2 spaces ;

: line dup address dup hexform 3 spaces charform cr ;

: dump ( addr count -- )
  cr 1 pick + swap do i line 16 +loop ;

 