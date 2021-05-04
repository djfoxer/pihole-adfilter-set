# pihole-adfilter-set

This small project brings fast and simple way to add in "one command" the whole bunch of blocked domains to [PiHole](https://pi-hole.net/).

Main file: [adfilterset.txt](https://raw.githubusercontent.com/djfoxer/pihole-adfilter-set/main/adfilterset.txt) contains 76 url sources that block 1 454 942 domains.

![PiHole blocked domains](https://github.com/djfoxer/pihole-adfilter-set/raw/main/doc/block1.PNG)

## Installation
Put this command into bash:
 ```bash
 pihole restartdns 
 sudo sqlite3 /etc/pihole/gravity.db "DELETE FROM adlist" 
 sudo wget -qO - https://raw.githubusercontent.com/djfoxer/pihole-adfilter-set/main/adfilterset.txt |xargs -I {} \
 sudo sqlite3 /etc/pihole/gravity.db "INSERT INTO adlist (Address) VALUES ('{}');" 
 pihole -g 
 bash 
 ```
 
 ## Command(s) description
 -  `pihole restartdns` restart dns for PiHole
 -  `sudo sqlite3 /etc/pihole/gravity.db "DELETE FROM adlist"` delete all old data from AdLists database in PiHole
 -  `sudo wget -qO - https://raw.githubusercontent.com/djfoxer/pihole-adfilter-set/main/adfilterset.txt |xargs -I {} \`  download [adfilterset.txt](https://raw.githubusercontent.com/djfoxer/pihole-adfilter-set/main/adfilterset.txt)
 -  `sudo sqlite3 /etc/pihole/gravity.db "INSERT INTO adlist (Address) VALUES ('{}');"`  insert urls into the PiHole database
 -  `pihole -g`  redownload and refresh AdLists in PiHole
