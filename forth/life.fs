
\ conway's life in Forth
\ Written to avoid as many arithmetic operations as possible
\ and using purely textual output


24 constant width
24 constant height

variable board1 width height * allot
variable board2 width height * allot

variable fromboard
variable toboard

: by24 4 lshift dup 1 rshift + ;

: swap-boards
  toboard @
  fromboard @ toboard !
  fromboard ! ;

: xytocount ( x y -- n )
    by24 + ;

: setzero ( board x y )
    xytocount + 0 swap c! ;

: setone ( board x y )
    xytocount + 1 swap c! ;

: flookup ( board x y -- value )
    by24 + + c@ ;

: addglider ( board -- )
  dup 2 4 setone
  dup 3 4 setone
  dup 4 4 setone
  dup 4 3 setone
  3 2 setone ;

: twogliders ( board -- )
  dup 2 4 setone
  dup 3 4 setone
  dup 4 4 setone
  dup 4 3 setone
  dup 3 2 setone

  dup 12 14 setone
  dup 13 14 setone
  dup 14 14 setone
  dup 14 13 setone
  13 12 setone ;


: neighbors ( n -- count )
    dup fromboard @ + c@ swap 
    1+ dup fromboard @ + c@ swap
    1+ dup fromboard @ + c@ swap
    width + dup fromboard @ + c@ swap
    width + dup fromboard @ + c@ swap 
    1- dup fromboard @ + c@ swap      
    1- dup fromboard @ + c@ swap      
    width - fromboard @ + c@          
    + + + + + + + ;

: checkvalid ( n -- f )
    width mod width 1- 1- < ;

: process-board
    height 2 - width 2 - * 0 do
      i checkvalid if
        i width + 1+
        \ dup i . . cr
        dup fromboard @ + c@ if
          i neighbors
          \ live cell, and dest offset is on the stack
          dup 2 < if
            drop                     \ drop the neighbor count
            toboard @ + 0 swap c!    \ dies of loneliness
          else
            3 > if
              toboard @ + 0 swap  c!   \ dies of overcrowding
            else
              toboard @ + 1 swap c!    \ continues
            then
          then
        else
          \ dead cell, and dest offset is on the stack
          i neighbors 3 = if
            toboard @ + 1 swap c!  \ born
          else
            toboard @ + 0 swap c!  \ continues
          then
        then
      then
    loop ;


: print ( board -- )
  height 0 do
    width 0 do
      dup i j flookup 0= if
        46 emit
      else
        42 emit
      then
    loop
    cr
  loop 
  drop ;

: life-reset
    board1 width height * 0 fill
    board2 width height * 0 fill
    board1 fromboard !
    board2 toboard !
    board1 twogliders ;

life-reset

: gen process-board page toboard @ print swap-boards ;

: 20cycle
    20 0 do gen loop ;

: 20key
    20 0 do gen ." press a key (q to quit) " key 113 = if leave then loop ;

