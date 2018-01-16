: fib1 ( n1 -- n2 )
    dup 2 < if drop 1 exit then
    dup 1- recurse
    swap 2- recurse + ;

\ how deep do the stacks need to be?
: fib1-bench 1000 0 do i fib1 drop loop ;

: fib2 ( n1 -- n2 )
   0 1 rot 0 do over + swap loop drop ;

: fib2-bench 1000 0 do i fib2 drop loop ;

