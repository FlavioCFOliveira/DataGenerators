pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code..'
                Checkout smc
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                bat 'nuget restore SolutionName.sln'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}