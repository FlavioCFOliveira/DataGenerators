pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code..'
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh label:'Restore & Build', script:'''
                    dotnet restore Xumiga.DataGenerators.sln
                    dotnet build Xumiga.DataGenerators.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.4.${env.BUILD_NUMBER}
                '''
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                sh("dotnet restore Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj")
                sh("dotnet test Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj --logger 'trx;LogFileName=${env.WORKSPACE}/TestsReport-1.0.4.${env.BUILD_NUMBER}.trx' -v n")
                mstest keepLongStdio: true
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: '**/Release/**/Xumiga.DataGenerators.dll', onlyIfSuccessful: true
            cleanWs deleteDirs: true
        }
    }

}