EXTERNAL load_scene(scene)

=== Intro
	Hello pink man, and welcome!
	*	[hello. who are you?] ->name
	+	[tell me your name] ->name

	= name
		My name is Rusty!
	->DONE
->END

=== rusty_scene_1
	Well good morning to you- hope you got some sleep with all the thunder last night.
	*	[I don't sleep much anyway...] ->insomnia
	*	[yeah... Can I help you with something officer...?] ->meet_rusty

	= insomnia
		Uh huh, well maybe some more fresh ocean air will help with that
	-> DONE

	= meet_rusty
		Rusty! Officer Rusty. But everyone 'round here just calls me Russ. I just wanted to introduce myself- seein as you'll be here for a while.
        *   [uh huh...] -> cabin
        *   [are you from here?] ->home
	->DONE

    = home
        Born and raised haha! 
    ->DONE

    = cabin
        Nice little spot up here. Glad someone is making use of it. Mrs. Dalia moved away after the flood and it's just been sitting empty since.
        *   [I really need to be getting to work...] ->goodbye
        *   [...flood?] ->flood
    ->DONE

    = flood
        Text about flood!!!
    ->DONE

    = goodbye
        Alright, I get it, gotta get it done.
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

=== gotomap
    you want to go to the map?
    + [yeah...] -> map
    + [naw...]
    ->DONE

    = map
    {load_scene("Map")}
    ->DONE 
->END