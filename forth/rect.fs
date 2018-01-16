: rect ( x y width height -- )
  2swap 2dup
  4 pick + swap 5 pick + 2swap
  dup 4 pick 1+ swap do
    1 pick i at-xy 42 emit
    2 pick i at-xy 42 emit
  loop
  2 pick 1+ 2 pick do
    dup i swap at-xy 42 emit
    i 4 pick at-xy 42 emit
  loop
  2drop 2drop 2drop
;
