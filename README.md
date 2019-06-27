# Project

The idea is to offer an windows program that will send a notification by e mail everytime the internet IP adress is modified where it is installed.
I’ve let parameterized to implement by factories other ways to processing after the confirmation that the IP adress has changed.

## Installation

Download the project at: https://github.com/andrebtoe/NotifyChangeIp/blob/master/Release.zip

```bash
NotifyChangeIp.exe install start
```

## Settings

Configure the windows service through the file App.config

* [identify] - Identifier is used together with e mail title
* [title] - E-mail title
* [hostAuth] - Host server sending e mail
* [mailAuth] - Authentication e-mail
* [passwordAuth] - Authentication password
* [sslAuth] - Define if ssl is used at the authentication
* [portAuth] - E-mail sending port number
* [emailTo] - E-mail destiny
* [type] - Notification processing type (MailNotifyIp)
* [logs] - Enable the use of logs at the event viwer
* [nameService] - Service name
* [timeService] - Time in the timespan format that the service must be performed on a recurring basis

## Factory
Add a new item https://andrebtoe.com/2019/06/27/servico-do-windows-para-monitorar-ip-com-c/

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
