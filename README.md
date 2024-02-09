Para instalar o applicativo:

É preciso ter instalado o docker e o docker-compose

No endereço da plataforma Git, acesse:
https://github.com/JLira/totvs-ats-back
e clone para sua maquina o projeto totvs-ats-back 

pode ser por ssh:
git@github.com:JLira/totvs-ats-back.git
ou https:
https://github.com/JLira/totvs-ats-back.git

Após a realização do clone, entre no diretorio o projeto, copie e cole em seu terminal 
o seguinte comando:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

isso irá montar os dois containers e será possivel executar o projeto pelo swagger com o seguinte comanddo:

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
