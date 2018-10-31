# Based on code from https://docs.python.org/2/library/imaplib.html#module-imaplib

import getpass, imaplib

# Function to hide my credentials from github. Credentials are stored in a .txt file on my Desktop
# This function should be altered to suit your filepath and credentials file.
def Read_Email_Creds():
    file = open('/home/jsneal/Desktop/Test_Email_Creds.txt', 'r') # Insert the path to a text file with your credentials and modify to suit your .txt file.
    username = file.readline()
    password = file.readline()
    return [username, password]

[gmail_user, gmail_password] = Read_Email_Creds()


M = imaplib.IMAP4_SSL('imap.gmail.com', 993)
M.login(gmail_user, gmail_password) 
M.select()
typ, data = M.search(None, 'ALL')
for num in data[0].split():
    typ, data = M.fetch(num, '(RFC822)')
    print 'Message %s\n%s\n' % (num, data[0][1])
M.close()
M.logout()
