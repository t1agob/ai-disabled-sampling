# ai-disabled-sampling
Sample project to show the behavior of Application Insights with Sampling completely disabled. You should be able to see all custom events in Application Insights Analytics.

More detailed instructions on how to configure it for your own usage will be provided soon.

Don't forget to:
* Update the Instrumentation Key value in ApplicationInsights.config in both web projects* Update 
* In AI_JOB project update the name of the queue and the connection strings for Azure Storage
* If you plan to use QueueLoad project you can easily change number of requests and time between requests in the configuration file
