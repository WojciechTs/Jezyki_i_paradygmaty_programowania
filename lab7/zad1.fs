type Book(title: string, autor: string, pages: int) =
    member this.Title = title
    member this.Autor = autor
    member this.Pages = pages
    member this.GetInfo() =
        printfn "Tytuł: %s, Autor: %s, Stron: %i" this.Title this.Autor this.Pages
        
type User(id: int, name: string, subname: string) =
    let mutable _books: Book List = []
    member this.Id = id
    member this.Name = name
    member this.Subname = subname
    member this.BorrowBook (book: Book) =
        _books <- book::_books
        printfn "Użytkownik %s %s wypożyczył:" this.Name this.Subname 
        book.GetInfo()
    member this.ReturnBook (book: Book) =
        let id = _books |> List.findIndex(fun c-> c = book)
        if id <> -1 then
            _books <- _books |> List.removeAt id
            printfn "Użytkownik %s %s oddał:" this.Name this.Subname 
            book.GetInfo()

type Library () =
    let mutable _books: Book List = []
    member this.AddBook (book: Book) =
        _books <- book::_books
        printfn "Dodano do biblioteki"
        book.GetInfo()
    member this.RemoveBook (book: Book) =
        let id = _books |> List.findIndex(fun c-> c = book)
        if id <> -1 then
            _books <- _books |> List.removeAt id
            printfn "Usunięto z biblioteki"
            book.GetInfo()
    member this.ListBooks () =
        printfn "Książki w bibliotece:"
        _books |> Seq.iter (fun c -> c.GetInfo())
        
    

        

    

[<EntryPoint>]
let main argv =
    let libaray = Library()
    let user = User(1,"John","Kowal")
    libaray.ListBooks()
    let book1 = Book("Quo vadis","Henryk Sienkiewicz",300)
    let book2 = Book("Makbet","William Shekespeare",200)
    let book3 = Book("Mój pamietnik","nieznany",30)
    libaray.AddBook(book1)
    libaray.AddBook(book2)
    libaray.AddBook(book3)
    libaray.ListBooks()
    user.BorrowBook(book2)
    user.BorrowBook(book1)
    user.ReturnBook(book2)

    0
