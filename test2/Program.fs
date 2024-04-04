// For more information see https://aka.ms/fsharp-console-apps

type Kind =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport


type FilmMaker = {
    Name: string
    Films: int
}


type Film = {
    Name: string
    Duration: int
    Kind: Kind
    FilmMaker: FilmMaker
    IMDBRanking: float
}


let films = [
    { Name = "CODA"; Duration = 111; Kind = Drama; FilmMaker = { Name = "Sian Heder"; Films = 9 }; IMDBRanking = 8.1 }
    { Name = "Belfast"; Duration = 98; Kind = Comedy; FilmMaker = { Name = "Kenneth Branagh"; Films = 23 }; IMDBRanking = 7.3 }
    { Name = "Don’t Look Up"; Duration = 138; Kind = Comedy; FilmMaker = { Name = "Adam McKay"; Films = 27 }; IMDBRanking = 7.2 }
    { Name = "Drive My Car"; Duration = 179; Kind = Drama; FilmMaker = { Name = "Ryusuke Hamaguchi"; Films = 16 }; IMDBRanking = 7.6 }
    { Name = "Dune"; Duration = 155; Kind = Fantasy; FilmMaker = { Name = "Denis Villeneuve"; Films = 24 }; IMDBRanking = 8.1 }
    { Name = "King Richard"; Duration = 144; Kind = Sport; FilmMaker = { Name = "Reinaldo Marcus Green"; Films = 15 }; IMDBRanking = 7.5 }
    { Name = "Licorice Pizza"; Duration = 133; Kind = Comedy; FilmMaker = { Name = "Paul Thomas Anderson"; Films = 49 }; IMDBRanking = 7.4 }
    { Name = "Nightmare Alley"; Duration = 150; Kind = Thriller; FilmMaker = { Name = "Guillermo Del Toro"; Films = 22 }; IMDBRanking = 7.1 }
]


let presumedOscar = List.filter (fun film -> film.IMDBRanking > 7.4) films

let transformDuration (minutes: int) =
    let hours = minutes / 60
    let Minutes = minutes % 60
    sprintf "%dh %dmin" hours Minutes

let durationHours = List.map (fun film -> transformDuration film.Duration) films


printfn "Movies along with their durations in hours:"
List.iter (fun film -> 
    let duration = transformDuration film.Duration
    printfn "- %s: %s" film.Name duration ) films

printfn "Presumed Oscar-winning films:"
List.iter (fun film -> printfn "- %s" film.Name) presumedOscar

printfn "Presumed Oscar-winning films with their durations in hours:"
List.iteri (fun i film -> 
    let duration = List.item i durationHours
    printfn "- %s: %s" film.Name duration) presumedOscar


printfn "Oscar-winning movies with their durations ratings and directors:"
List.iter (fun film -> 
    let duration = transformDuration film.Duration
    printfn "- %s: Duration: %s, Rating: %.1f, %s" film.Name duration film.IMDBRanking film.FilmMaker.Name) presumedOscar
