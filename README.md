# Filesplitter - a tool to split big files

https://github.com/PatriceDargenton/FileSplitter

Upgraded from this original source code:
Filesplitter, un utilitaire pour découper et joindre des fichiers

http://codes-sources.commentcamarche.net/source/28107-filesplitter-un-utilitaire-pour-decouper-et-joindre-des-fichiers


# Example: how to seek a big sql file?
You can split a large sql file in 320 Mb chuncks, and seek them using [VBFileFind](http://patrice.dargenton.free.fr/CodesSources/VBFileFind.html) with *.part and option "Casse" (upper and lower case enforcement) and ASCII/ANSI setted, then you can easily find a text with Notepad++, for example "CREATE TABLE `MyTable".

# ToDo
- Cancel

# Versions

## 01/04/2020 V1.0.1
- Speed: not computed, so not shown
- Big file support: SizeLimit: int -> long
- txtFolderPath.Text setted automatically after choosing the file
- Fixed: System.InvalidOperationException, HResult=-2146233079: Cross-thread operation not valid
- Source code update for Visual Studio 2019

## 21/08/2013 V1.0.0 Original version from eRRaTuM
Filesplitter, un utilitaire pour découper et joindre des fichiers

http://codes-sources.commentcamarche.net/source/28107-filesplitter-un-utilitaire-pour-decouper-et-joindre-des-fichiers

Patrice Dargenton.