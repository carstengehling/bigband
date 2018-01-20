# BigBand
Orchestration for remote Windows environments

# Concept

**BigBand** is a project, that aims to make it easy for system administrators to run various PowerShell scripts on a large number of Windows computers (servers as well as clients). Each computer installs an agent service (called an "Artist"). At first run, each Artist registrates itself to a central server (the "Conductor"). After this, each Artist periodically queries the Conductor for any jobs to perform (any "Compositions" to "Play").

| Term | Definition |
| ---- | ---------- |
| **Conductor** | The central service API, on which all Artists registers and queries for Compositions to play.<br>This is also where a user does all administration of the entire orchestration. |
| **Artist** | The agent service that does the actual work on each computer, that it is installed on. |
| **Ensemble** | Artists can be grouped in Ensembles to simplify running the same Compositions on multiple computers. |
| **Composition** | The PowerShell scripts that a sys-admin creates to run on various computers. |
| **Performance** | When an Artist has played a Composition, it sends back a report to the Conductor whether it went well, and the output. This is the Performance. |

## Artist registration

             +---------+                   +-----------+                                    +-----------+
             | Artist  |                   | Conductor |                                    | Ensemble  |
             +---------+                   +-----------+                                    +-----------+
    ------------\ |                              |                                                |
    | Installed |-|                              |                                                |
    |-----------| |                              |                                                |
                  |                              |                                                |
                  | Register into Ensemble       |                                                |
                  |----------------------------->|                                                |
                  |                              |                                                |
                  |                              | Validate artist credentials and register       |
                  |                              |----------------------------------------------->|
                  |                              |                                                |
                  |                              |                                             OK |
                  |                              |<-----------------------------------------------|
                  |                              |                                                |
                  |        Registration approved |                                                |
                  |<-----------------------------|                                                |
                  |                              |                                                |
                  
## Artist query

            +---------+                      +-----------+
            | Artist  |                      | Conductor |
            +---------+                      +-----------+
    -----------\ |                                 |
    | Periodic |-|                                 |
    |----------| |                                 |
                 |                                 |
                 | Get unplayed compositions       |
                 |-------------------------------->|
                 |                                 |
                 |          List of 2 compositions |
                 |<--------------------------------|
                 |                                 |
                 | Play composition                |
                 |-----------------                |
                 |                |                |
                 |<----------------                |
                 |                                 |
                 | Submit performance              |
                 |-------------------------------->|
                 |                                 |
                 |                    Acknowledged |
                 |<--------------------------------|
                 |                                 |
                 | Play composition                |
                 |-----------------                |
                 |                |                |
                 |<----------------                |
                 |                                 |
                 | Submit performance              |
                 |-------------------------------->|
                 |                                 |
                 |                    Acknowledged |
                 |<--------------------------------|
                 |                                 |
