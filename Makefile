
XA=xa

%.x65: %.a65
	$(XA) -l `basename $< .a65`.lab -o $@ $<
