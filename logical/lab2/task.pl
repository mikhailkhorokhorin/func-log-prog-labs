color(dove, light).
color(parrot, light).
color(raven, dark).
color(rook, dark).
color(canary, light).
color(gull, light).
color(starling, dark).

namesake('Voronov', raven).
namesake('Golubev', dove).
namesake('Kanareykin', canary).
namesake('Grachev', rook).
namesake('Chaikin', gull).
namesake('Skvortsov', starling).
namesake('Popugaev', parrot).

solve(Solution) :-
    People = [
        person('Voronov', VoronovBird, married),
        person('Golubev', GolubevBird, single),
        person('Kanareykin', KanareykinBird, single),
        person('Grachev', GrachevBird, married),
        person('Chaikin', ChaikinBird, married),
        person('Skvortsov', SkvortsovBird, married),
        person('Popugaev', PopugaevBird, married)
    ],

    Birds = [VoronovBird, GolubevBird, KanareykinBird, GrachevBird, ChaikinBird, SkvortsovBird, PopugaevBird], 
    
    permutation([raven, dove, canary, rook, gull, starling, parrot], Birds),

    VoronovBird \= raven,
    GolubevBird \= dove,
    KanareykinBird \= canary,
    GrachevBird \= rook,
    ChaikinBird \= gull,
    SkvortsovBird \= starling,
    PopugaevBird \= parrot,

    forall(member(person(Surname, Bird, _), People),
        (color(Bird, dark) -> 
            member(Surname, ['Golubev', 'Kanareykin', 'Chaikin', 'Popugaev']) 
        ; true)),

    namesake(TezkaVoronova, VoronovBird), 
    member(person(TezkaVoronova, _, married), People),

    ChaikinBird \= rook,

    member(person(_, rook, married), People),

    member(person(_, raven, single), People),
    
    member(person('Grachev', GrachevBird, _), People),
    namesake(TezkaGracheva, GrachevBird),
    member(person(TezkaGracheva, canary, _), People),
   
    member(person(PopugaiOwner, parrot, _), People),
    namesake(PopugaiOwner, Bird1),
    member(person(Bird1Owner, Bird1, _), People),
    namesake(PersonV, VoronovBird),
    Bird1Owner = PersonV,
    
    member(person(Solution, starling, _), People).
    