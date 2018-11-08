import sys
from fetchEmailData import fetchEmailData
from organizeEmailData import organizeEmailData

"""
Module designed by John Neal (jsneal519@gmail.com) for EC601 class at Boston University

I definitely recieved some help from Python docs related to accessing the Gmail account.
Note that I cite the URL of my source from the Python docs in fetchEmailData

This is the main module that connects the python email modules that will be used for gathering info from an email account
and sending it to our app which will allow the user to choose certain options based on eye movements from the Tobii EyeX.

The python modules only have to connect to the email account, extract the inbox information and organize this information
in a form that is accessible for our app.

So far this module has only been verified with a gmail account.

If you wish to use your own Gmail account, you have to enable "less secure apps" for your Google account. Google does not
recommend this. Therefore, I would suggest creating a test email account with Gmail and sending dummy emails into its inbox
to play around with these modules and experiment.
---------
functions
---------
fetchEmailData(): reads account info from .txt file, logs in to gmail account, requests and recieves data from Gmail inbox.
	returns --> emailDataList - a list with the data corresponding to each email.

organizedDataList(emailDataList): takes the data from fetchEmailData, extracts the significant email info we need for our app
and then puts this data in a list structure where each element is a dictionary with keys that correspond to the "significant"
fields of info from the email. These keys correspond to Subject, From, To, Content, Date.
	returns --> organizedDataList - a list where each element is a dictionary with keys that correspond to the fields of
	"significant" email info. While we are in the early stages of developing the app, this data structure is how we will
	access this info for the app.
"""


emailDataList = fetchEmailData() 
organizedDataList = organizeEmailData(emailDataList)
#sys.stdout.write(organizedDataList) # so that the string of the dictionary can be sent to stdout


