module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State
open Global

importAll "../sass/main.sass"

open Fable.Helpers.React
open Fable.Helpers.React.Props

type Model =
    { x : int }

type Msg = 
    | Increment
    | Decrement

let init () =
    ({ x = 0 }, Cmd.none)

let update msg model =
    match msg with
    | Increment -> 
        ({ model with x = model.x + 1 }, Cmd.none)
    | Decrement -> 
        ({ model with x = model.x - 1 }, Cmd.none)

let view model dispatch =
    div []
        [ button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
          div [] [ str (model.x.ToString()) ]
          button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update view
#if DEBUG
|> Program.withDebugger
#endif
|> Program.withReact "elmish-app"
|> Program.run
