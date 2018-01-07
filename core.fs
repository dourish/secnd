: space 32 emit ;
: spaces 0 do space loop ;
: clear 74 50 91 27 emit emit emit emit ;
: home 72 91 27 emit emit emit ;
: page clear home ;