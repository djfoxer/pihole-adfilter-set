# pihole-adfilter-set

 ```bash
 pihole restartdns 
 sudo sqlite3 /etc/pihole/gravity.db "DELETE FROM adlist" 
 sudo wget -qO - https://raw.githubusercontent.com/djfoxer/pihole-adfilter-set/main/main.txt |xargs -I {} \
 sudo sqlite3 /etc/pihole/gravity.db "INSERT INTO adlist (Address) VALUES ('{}');" 
 pihole -g 
 bash 
 ```
