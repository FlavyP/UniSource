% compute fibonacci numbers
-module(fib).
-export([start/0, fib/1, sfib/1]).

start() -> spawn(fun loop/0).

fib(N) ->
	Pid = start(),
	Qid = start(),
	Pid ! {self(), N-1},
	Qid ! {self(), N-2},
	receive
		{_, ResponseP} ->
			receive
				{_, ResponseQ} ->
ResponseP + ResponseQ
			end
end.

sfib(0) -> 1;
sfib(1) -> 1;
sfib(N) -> sfib(N-1) + sfib(N-2).

loop() -> receive
	{From, N} ->
		From ! {self(), sfib(N)},
		loop()
	end.
		