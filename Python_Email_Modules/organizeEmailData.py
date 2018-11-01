from base64 import b64decode


def organizeEmailData(emailDataList):
	organizedDataList = []
	counter = 0
	for data in emailDataList:
		#print(data[0])
		#print('\n\n\n\n\n\n')
		#print('data[0][0]')
		#print(data[0][0])
		#print('\n\n\n\n\n\n\n')
		"""counter = counter + 1
		datastr = 'Data: ' + str(counter)
		print('\n\n\n')
		print(datastr)
		print(data[0][1])"""
		print('\n\n\n')
		reducedData = data[0][1]
		#reducedData = data[0][1].split('Date: ')[1] # Gets rid of all of the completely uninteresting MIME message info
		Subject = reducedData.split('Subject:')[1].split('\n', 1)[0].strip(' ')
		From = reducedData.split('From:')[1].split('\n', 1)[0].strip(' ')
		To = reducedData.split('To:')[1].split('\n', 1)[0].strip(' ')
		Date = reducedData.split('Date:')[1].split('\n', 1)[0].strip(' ')
		Content = reducedData.split('Content-Transfer-Encoding: quoted-printable')[1].split('\n', 1)[1].strip().split('</html>')[0]
		if Content.find('<html') != -1:
			Content = Content + '</html>'
		print(From)
		print(To)
		print(Subject)
		print(Date)
		print('\n')
		print(Content)
	    #print('\n\n\n')
		#print('data[0][1].split("Subject:")[1]')
		#print(data[0][1].split('Subject:')[1])
		#print('data[0][1].split("Subject:")[1].split("\n", 1)[0].strip(" ")')
		#print(data[0][1].split('Subject:')[1].split('\n', 1)[0].strip(' '))
		#print(data[0][1])
	return []

	