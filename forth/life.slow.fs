
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

: north-coords ( x1 y1 -- x2 y2 )
    1- ;

: south-coords
    1+ ;

: east-coords
    swap 1+ swap ;

: west-coords
    swap 1- swap ;

: ne-coords
  north-coords east-coords ;

: sw-coords
  south-coords west-coords ;

: se-coords
  south-coords east-coords ;

: nw-coords
  north-coords west-coords ;

: xytocount ( x y -- n )
    width * + ;

: lookup ( board x y -- value )
    xytocount + c@ ;

: setzero ( board x y )
    xytocount + 0 swap c! ;

: setone ( board x y )
    xytocount + 1 swap c! ;

: flookup ( board x y -- value )
    by24 + + c@ ;

: count-north
    north-coords lookup ;
: count-south
    south-coords lookup ;
: count-west
    west-coords lookup ;
: count-east
    east-coords lookup ;

: count-ne
  ne-coords lookup ;

: count-se
  se-coords lookup ;

: count-sw
  sw-coords lookup ;

: count-nw
  nw-coords lookup ;


: neighbors ( board x y -- count )
    2dup 4 pick rot rot count-north
    3 pick 3 pick 3 pick count-south
    4 pick 4 pick 4 pick count-east
    5 pick 5 pick 5 pick count-west
    6 pick 6 pick 6 pick count-nw
    7 pick 7 pick 7 pick count-ne
    8 pick 8 pick 8 pick count-sw
    9 pick 9 pick 9 pick count-se
    + + + + + + +
    swap drop swap drop swap drop ;

: fneighbors ( x y -- count) 
    1- swap 1- swap    \ calculate NW point
    by24 +             \ convert coords to an offset
    dup fromboard @ + c@ swap  \ fetch data, place under dup'd location
    1+ dup fromboard @ + c@ swap \ same with N point
    1+ dup fromboard @ + c@ swap \ then NE point
    width + dup fromboard @ + c@ swap \ then E point
    width + dup fromboard @ + c@ swap \ then SE point
    1- dup fromboard @ + c@ swap      \ then S point
    1- dup fromboard @ + c@ swap      \ then SW point
    width - fromboard @ + c@          \ finally, W point
    + + + + + + + ;


: addglider ( board -- )
  dup 2 4 setone
  dup 3 4 setone
  dup 4 4 setone
  dup 4 3 setone
  3 2 setone ;

: fprocess
    height 1- 1 do
      width 1- 1 do
        fromboard @ i j flookup 1 = if
          \ live cell
          i j fneighbors
          dup 2 < if
            toboard @ i j setzero   \ dies of loneliness
            drop
          else
            3 > if
              toboard @ i j setzero   \ dies of overcrowding
            else
              toboard @ i j setone    \ continues
            then
          then
        else
          \ dead cell
          i j fneighbors 3 = if
            toboard @ i j setone  \ born
          else
            toboard @ i j setzero  \ continues
          then
        then
      loop
    loop ;


: process-board
    height 1- 1 do
      width 1- 1 do
        fromboard @ i j lookup 1 = if
          \ live cell
          fromboard @ i j neighbors
          dup 2 < if
            toboard @ i j setzero   \ dies of loneliness
            drop
          else
            3 > if
              toboard @ i j setzero   \ dies of overcrowding
            else
              toboard @ i j setone    \ continues
            then
          then
        else
          \ dead cell
          fromboard @ i j neighbors 3 = if
            toboard @ i j setone  \ born
          else
            toboard @ i j setzero  \ continues
          then
        then
      loop
    loop ;



: print ( board -- )
  height 0 do
    width 0 do
      dup i j lookup 0= if
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
    board1 addglider ;

life-reset

: fgen fprocess page toboard @ print swap-boards ;

: gen process-board page toboard @ print swap-boards ;

: 20gens 20 0 do gen ." press a key " key drop loop ;

: 15gens 15 0 do gen loop ;

: 20fgen 20 0 do gen ." press a key (q to quit) " key 113 = if leave then loop ;

