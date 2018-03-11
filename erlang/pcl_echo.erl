% demo process creation
-module(pcl_echo).
-export([start/0, loop/0]).

start() -> spawn(pcl_echo, loop, []).

loop() -> receive {From, Message} -> io:format("> pcl_echo: ~w Message: ~w ~n", [self(), Message]),
									 From ! Message,
									 loop()
end.