module Login

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fetch.Types
open Thoth.Fetch
open Fulma
open Thoth.Json
open Feliz
open Feliz.UseElmish

type LoginProps = { LoggedIn : Shared.LogIn -> unit }

type Msg = LoginClicked

type State = LoggedIn | NotLoggedIn

let init = NotLoggedIn, Cmd.none

let update props msg _ =
    match msg with
    | LoginClicked -> LoggedIn, Cmd.ofSub (fun _ -> { Shared.LoggedIn = true } |> props.LoggedIn)

let loginComponent = React.functionComponent("login", fun (props: LoginProps) ->
    let state, dispatch = React.useElmish(init, update props, [||])

    Html.div [
        Html.button [
            prop.text "Click to login"
            prop.onClick (fun _ -> (LoginClicked |> dispatch))
        ]
    ]
)

let render props = loginComponent props