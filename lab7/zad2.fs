type BankAccount (AccountNumber: int, Balance :float ) =
    let mutable _account = AccountNumber
    let mutable _balance: float = Balance
    member this.AccountNumber  = _account
    member this.Balance = _balance
    member this.Deposit (input: float) =
        _balance <- _balance + input
        printfn "Depozynowano %f na Account number: %i" input this.AccountNumber
    member this.Withdraw (input) =
        if input <= _balance then
            _balance <- _balance - input
            printfn "Wypłacono %f z Account number: %i" input this.AccountNumber
        else
            printfn "Nie ma tylu środów na Account number: %i" this.AccountNumber

type Bank () =
    let mutable _accounts: BankAccount List = []
    member this.CreateAccount(accountNumber: int, Balance :float) =
        let account = BankAccount(accountNumber,Balance)
        _accounts <- account::_accounts
        printfn "Utworzono Account number: %i" accountNumber
    member this.GetAccount (accountNumber: int) =
        let account = _accounts |> List.find(fun c -> c.AccountNumber = accountNumber)
        if account.AccountNumber=accountNumber then
            printfn "Account number: %i; Balance: %f" account.AccountNumber account.Balance
        else    
            printfn "Account number: %i nie znalezione!" accountNumber
    member this.UpdateAccount (accountNumber: int, balance: float) =
        let account = _accounts |> List.find(fun c -> c.AccountNumber = accountNumber)
        if account.AccountNumber=accountNumber then
            if balance >= 0.0 then
                account.Deposit balance
            else
                account.Withdraw balance
            printfn "Account number: %i; Balance: %f" account.AccountNumber account.Balance
        else    
            printfn "Account number: %i nie znaleziono!" accountNumber
    member this.DeleteAccount (accountNumber: int) =
        let account = _accounts |> List.findIndex(fun c -> c.AccountNumber = accountNumber)
        if account <> -1 then
            _accounts <- _accounts |> List.removeAt account
            printfn "Account number: %i zostało usuniete" accountNumber
        else
            printfn "Account number: %i nie znaleziono" accountNumber
         

[<EntryPoint>]
let main argv =
    let bank = Bank ()
    bank.CreateAccount(1,10.0)
    bank.CreateAccount(2,3410.0)
    bank.CreateAccount(3,50.50)

    bank.GetAccount(1)
    bank.UpdateAccount(1,450.0)
    bank.GetAccount(2)
    bank.UpdateAccount(2,-2000.0)
    bank.GetAccount(3)
    bank.UpdateAccount(3,-60.0)
    
    bank.DeleteAccount(3)
    0
