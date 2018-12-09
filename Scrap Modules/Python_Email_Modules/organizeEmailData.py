"""
Module designed by John Neal (jsneal519@gmail.com) for EC601 class at Boston University

Understanding this module comes down to playing with the recieved emailDataList and seeing how that data is organized.

Each element of the emailDataList is organized in a very nonsensical way. If we take a single element of this list and
call the variable 'data,' try running print statements to understand the structure of this. Then all of the long
'strip' and 'split' statements will begin to make sense.

'data[0][1]' is simply one giant ass string that you have to split up to use.
"""
def organizeEmailData(emailDataList):
	organizedDataList = []
	for data in emailDataList:
		emailDict = {'Subject': '', 'From': '', 'To': '', 'Date': '', 'Content': ''} # initializing an element in our organizedDataList
		reducedData = data[0][1] # Significantly reduces the size of the string so we don't have to "carry it around" through each split assignment
		Subject = reducedData.split('Subject:')[1].split('\n', 1)[0].strip(' ')
		From = reducedData.split('From:')[1].split('\n', 1)[0].strip(' ')
		To = reducedData.split('To:')[1].split('\n', 1)[0].strip(' ')
		Date = reducedData.split('Date:')[1].split('\n', 1)[0].strip(' ')
		Content = reducedData.split('Content-Transfer-Encoding: quoted-printable')[1].split('\n', 1)[1].strip().split('</html>')[0]
		if Content.find('<html') != -1:	# If the quoted-printable form is in html then, since we split at </html> we have to readd it
			Content = Content + '</html>'
		emailDict['Subject'] = Subject	# Assigning to fields of emailDict
		emailDict['From'] = From
		emailDict['To'] = To
		emailDict['Date'] = Date
		emailDict['Content'] = Content
		organizedDataList.append(emailDict)
	return organizedDataList

	