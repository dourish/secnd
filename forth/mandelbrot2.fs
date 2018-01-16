\ setup constants to remove magic numbers to allow
\ for greater zoom with different scale factors.
20  constant maxiter
-39 constant minval
40  constant maxval
20 5 lshift constant rescale
rescale 4 * constant s_escape

\ these variables hold values during the escape calculation.
variable creal
variable cimag
variable zreal
variable zimag
variable count

\ compute squares, but rescale to remove extra scaling factor.
: zr_sq zreal @ dup rescale */ ;
: zi_sq zimag @ dup rescale */ ;

\ translate escape count to ascii greyscale.
: .char
  s" ..,'~!^:;[/<&?oxox#  "
  drop + 1
  type ;

\ numbers above 4 will always escape, so compare to a scaled value.
: escapes?
  s_escape > ;

\ increment count and compare to max iterations.
: count_and_test?
  count @ 1+ dup count !
  maxiter > ;

\ stores the row column values from the stack for the escape calculation.
: init_vars
  5 lshift dup creal ! zreal !
  5 lshift dup cimag ! zimag !
  1 count ! ;

\ performs a single iteration of the escape calculation.
: doescape
    zr_sq zi_sq 2dup +
    escapes? if
      2drop
      true
    else
      - creal @ +   \ leave result on stack
      zreal @ zimag @ rescale */ 1 lshift
      cimag @ + zimag !
      zreal !                   \ store stack item into zreal
      count_and_test?
    then ;

\ iterates on a single cell to compute its escape factor.
: docell
  init_vars
  begin
    doescape
  until
  count @
  .char ;

\ for each cell in a row.
: dorow
  maxval minval do
    dup i
    docell
  loop
  drop ;

\ for each row in the set.
: mandelbrot
  cr
  maxval minval do
    i dorow cr
  loop ;

\ run the computation.
mandelbrot