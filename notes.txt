gitrepo=https://github.com/codinesh/shpstore.git

webappname=sphstore

az webapp deployment source config --name $webappname --resource-group Default-SQL-SoutheastAsia \
--repo-url $gitrepo --branch master --manual-integration
