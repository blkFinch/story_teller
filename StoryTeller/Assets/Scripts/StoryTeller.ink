=== Intro
	Hello pink man, and welcome!
	*	[hello. who are you?] ->name
	+	[tell me your name] ->name

	= name
		My name is Rusty!
	->DONE
->END

=== scene_1
	Well good morning to you- hope you got some sleep with all the thunder last night.
	*	[I don't sleep much anyway...] ->insomnia
	*	[yeah... Can I help you with something officer...?] ->meet_rusty

	= insomnia
		Uh huh, well maybe some more fresh ocean air will help with that
	-> DONE

	= meet_rusty
		Rusty! Officer Rusty. But everyone 'round here just calls me Russ. I just wanted to introduce myself- seein as you'll be here for a while.
	->DONE
->END

=== coin_flip
    I'll flip a coin! Heads or tails?
    +   [heads!] ->flip
    +   [tails] ->flip 

    =flip 
    {~ Heads | Tails } 
    ->DONE
->END