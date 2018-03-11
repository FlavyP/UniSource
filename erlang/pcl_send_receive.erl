% A demo of sneding, receiving and handling messages
% processes share no memory
% communicate via message passing
-module (pcl_send_receive).
-compile([export_all]).

serve() -> 
	receive
		Request ->
			io:format("Processing: ~s~n", [Request]),
			serve()
end.

domaths() ->
	receive
		{pcl_add, X, Y} ->
			io:format("~p + ~p = ~p~n", [X,Y,X+Y]),
			domaths();
		{pcl_sub, X, Y} ->
			io:format("~p - ~p = ~p~n", [X,Y,X-Y]),
			domaths()
end.

make_request(ServerId, Msg) ->
	ServerId ! Msg.
	
run() -> 
	Pid = spawn(?MODULE, server, []),
	make_request(Pid, request1),
	make_request(Pid, request2),
	timer:sleep(10),
	Pid2 = spawn(?MODULE, domaths, []),
	Pid2 ! {pcl_add, 1, 2},
	Pid2 ! {pcl_sub, 3, 2},
	ok.