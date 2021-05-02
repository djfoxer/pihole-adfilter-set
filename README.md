# pihole-all-in-1

 ```bash
 pihole restartdns 
 sudo sqlite3 /etc/pihole/gravity.db "DELETE FROM adlist" 
 sudo wget -qO - https://raw.githubusercontent.com/djfoxer/pihole-all-in-1/main/main.txt |xargs -I {} \
 sudo sqlite3 /etc/pihole/gravity.db "INSERT INTO adlist (Address) VALUES ('{}');" 
 pihole -g
 bash
 ```
