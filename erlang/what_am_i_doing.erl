-module(what_am_i_doing).
-export([loop/0]).
loop() ->
 receive X when is_num(X) ->
 if
 X < 0 -> io:format("The Number is negative~n");
 X > 0 -> io:format("The Number is positive~n");
 X == 0 -> io:format("The Number is zero~n")
 end,
 loop();
 "bye" ->
 io:format("Bye~n");
 _ ->
 io:format("Unexpected message~n"),
 loop()
 end.