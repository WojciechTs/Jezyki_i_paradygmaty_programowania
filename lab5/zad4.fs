let rec TowerOfHanoi from dest temp disks =
    if disks > 0 then
        TowerOfHanoi from temp dest (disks - 1)
        printfn "Moving from %c to %c" from dest
        TowerOfHanoi temp dest from (disks - 1)
        
TowerOfHanoi '1' '2' '3' 4
