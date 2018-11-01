


def organizeEmailData(emailDataList):
	for data in emailDataList:
		#print(data[0])
		#print('\n\n\n\n\n\n')
		#print('data[0][0]')
		#print(data[0][0])
		#print('\n\n\n\n\n\n\n')
		#print('data[0][1].split("Subject:")[1]')
		#print(data[0][1].split('Subject:')[1])
		#print('data[0][1].split("Subject:")[1].split("\n", 1)[0].strip(" ")')
		print(data[0][1].split('Subject:')[1].split('\n', 1)[0].strip(' '))

	